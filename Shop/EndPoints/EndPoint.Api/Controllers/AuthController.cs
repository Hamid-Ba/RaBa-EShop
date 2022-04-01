using Application.Contract.UserAgg;
using Application.UserAgg.Register;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Presentation.Api;
using Framework.Presentation.Api.JwtTools;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.UserAgg;

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

            var jwtDto = new JwtDto(user.Id, $"{user.FirstName} {user.LastName}", user.PhoneNumber);

            var result = _jwtHelper.SignIn(jwtDto);

            return new ApiResult<string>()
            {
                Data = result,
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