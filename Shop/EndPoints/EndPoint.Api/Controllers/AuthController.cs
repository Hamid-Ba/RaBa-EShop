using Application.Contract.UserAgg;
using Application.UserAgg.AddToken;
using Application.UserAgg.Register;
using Application.UserAgg.UpdateToken;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Presentation.Api;
using Framework.Presentation.Api.JwtTools;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.UserAgg;
using Query.UserAgg.DTOs;
using UAParser;

namespace EndPoint.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserFacade _userFacade;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(IJwtHelper jwtHelper, IUserFacade userFacade, IPasswordHasher passwordHasher)
        {
            _jwtHelper = jwtHelper;
            _userFacade = userFacade;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterUserCommand command) => CommandResult(await _userFacade.Register(command));

        [HttpPost("login")]
        public async Task<ApiResult> Login(LoginDto loginDto)
        {
            var user = await _userFacade.GetBy(loginDto.PhoneNumber);

            if (user is null)
                return CommandResult(OperationResult.NotFound("کاربری با این مشخصات یافت نشد"));

            if (!_passwordHasher.Check(user.Password, loginDto.Password).Verified)
                return CommandResult(OperationResult.Error("رمزعبور درست نمی باشد"));

            if (user.IsActive == false)
                return CommandResult(OperationResult.Error("حساب کاربری شما غیرفعال است"));

            var result = await GetToken(user,true);

            return result;
        }

        [HttpPut("RefreshToken/{refreshToken}")]
        public async Task<ApiResult> RefreshToken(string refreshToken)
        {
            var token = await _userFacade.GetTokenBy(refreshToken);
            if (token is null) return CommandResult(OperationResult.NotFound("Token Couldn't Be Found"));

           // if (token.TokenExpireDate > DateTime.Now) return CommandResult(OperationResult.Error("توکن هنوز منقضی نشده است"));
           // if (token.RefreshTokenExpireDate < DateTime.Now) return CommandResult(OperationResult.Error("زمان رفرش توکن به پایان رسیده است"));

            var user = await _userFacade.GetBy(token.UserId);

            var newToken = await GetToken(user,false);

            var newHashToken = Sha256Hasher.Hash(newToken.Data.Token);
            var newHashRefreshToken = Sha256Hasher.Hash(newToken.Data.RefreshToken);

            var updateTokenCommand = new UpdateTokenCommand(token.Id, newHashToken, newHashRefreshToken, DateTime.Now.AddDays(6), DateTime.Now.AddDays(7));
            updateTokenCommand.UserId = user.Id;

            var result = await _userFacade.UpdateToken(updateTokenCommand);

            if (result.Status == OperationResultStatus.Success)
                return newToken;

            return CommandResult(OperationResult.Error());
        }

        private async Task<ApiResult<LoginResultDto>> GetToken(UserDto user,bool wantToAddToken)
        {
            var uaParser = Parser.GetDefault();
            var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
            var device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";

            var jwtDto = new JwtDto(user.Id, $"{user.FirstName} {user.LastName}", user.PhoneNumber);

            var token = _jwtHelper.SignIn(jwtDto);
            var refreshToken = Guid.NewGuid().ToString();

            var hashToken = Sha256Hasher.Hash(token);
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

            if (wantToAddToken)
            {
                var tokenCommand = new AddTokenCommand(user.Id, hashToken, hashRefreshToken, DateTime.Now.AddDays(6), DateTime.Now.AddDays(7), device);

                var result = await _userFacade.AddToken(tokenCommand);

                if (result.Status == OperationResultStatus.Success)
                    return new ApiResult<LoginResultDto>()
                    {
                        Data = new(token, refreshToken),
                        IsSuccess = true,
                        MetaData = new()
                        {
                            Message = "ورود با موفقیت انجام شد",
                            Status = ApiStatusCode.Success
                        }
                    };

                return new ApiResult<LoginResultDto>
                {
                    Data = new LoginResultDto("", ""),
                    IsSuccess = false,
                    MetaData = new()
                    {
                        Status = ApiStatusCode.BadRequest,
                        Message = "شما نمی توانید وارد شوید"
                    }
                };
            }

            return new ApiResult<LoginResultDto>()
            {
                Data = new(token, refreshToken),
                IsSuccess = true,
                MetaData = new()
                {
                    Message = "ورود با موفقیت انجام شد",
                    Status = ApiStatusCode.Success
                }
            };
        }
    }
}