using Application.UserAgg.Active;
using Application.UserAgg.ChangePassword;
using Application.UserAgg.ChargeWallet;
using Application.UserAgg.Create;
using Application.UserAgg.DeActive;
using Application.UserAgg.Edit;
using Application.UserAgg.Register;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Framework.Presentation.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.UserAgg;
using Query.UserAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade) => _userFacade = userFacade;

        [HttpGet]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult<UserFilterResult>> GetAll([FromQuery] UserFilterParam param) => QueryResult(await _userFacade.GetAll(param));

        [HttpGet("{id}/{phone}")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult<UserDto>> Get(long id, string phone) =>
            id == 0 ? await GetBy(phone) : await GetBy(id);

        [HttpGet("getCurrent")]
        public async Task<ApiResult<UserDto>> GetCurrent() => QueryResult(await _userFacade.GetBy(User.GetUserId()));

        [PermissionChecker(Permission.User_Management)]
        private async Task<ApiResult<UserDto>> GetBy(long id) => QueryResult(await _userFacade.GetBy(id));

        [PermissionChecker(Permission.User_Management)]
        private async Task<ApiResult<UserDto>> GetBy(string phone) => QueryResult(await _userFacade.GetBy(phone));

        [HttpPost]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> Create([FromForm] CreateUserCommand command) => CommandResult(await _userFacade.Create(command));

        [HttpPost("register")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> Register(RegisterUserCommand command) => CommandResult(await _userFacade.Register(command));

        [HttpPost("chargeWallet")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> ChargeWallet(ChargeWalletCommand command) => CommandResult(await _userFacade.ChargeWallet(command));

        [HttpPut]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command) => CommandResult(await _userFacade.Edit(command));

        [HttpPut("changePassword")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> ChangePassword(ChangePasswordCommand command) => CommandResult(await _userFacade.ChangePassword(command));

        [HttpPut("active")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> Active(ActiveUserCommand command) => CommandResult(await _userFacade.Active(command));

        [HttpPut("deActive")]
        [PermissionChecker(Permission.User_Management)]
        public async Task<ApiResult> DeActive(DeActiveUserCommand command) => CommandResult(await _userFacade.DeActive(command));
    }
}