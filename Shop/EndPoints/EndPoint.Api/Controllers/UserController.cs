using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserAgg.AddAddress;
using Application.UserAgg.ChangePassword;
using Application.UserAgg.ChargeWallet;
using Application.UserAgg.Create;
using Application.UserAgg.DeleteAddress;
using Application.UserAgg.Edit;
using Application.UserAgg.EditAddress;
using Application.UserAgg.Register;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.UserAgg;
using Presentation.Facade.UserAgg.UserAddress;
using Query.UserAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IUserAddressFacade _userAddressFacade;

        public UserController(IUserFacade userFacade, IUserAddressFacade userAddressFacade)
        {
            _userFacade = userFacade;
            _userAddressFacade = userAddressFacade;
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetAll([FromQuery] UserFilterParam param) => QueryResult(await _userFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto>> GetBy(long id) => QueryResult(await _userFacade.GetBy(id));

        [HttpGet("{phone}")]
        public async Task<ApiResult<UserDto>> GetBy(string phoneNumber) => QueryResult(await _userFacade.GetBy(phoneNumber));

        [HttpPost]
        public async Task<ApiResult> Create(CreateUserCommand command) => CommandResult(await _userFacade.Create(command));

        [HttpPost("register")]
        public async Task<ApiResult> Register(RegisterUserCommand command) => CommandResult(await _userFacade.Register(command));

        [HttpPost("addAddress")]
        public async Task<ApiResult> AddAddress(AddAddressCommand command) => CommandResult(await _userAddressFacade.Add(command));

        [HttpPost("chargeWallet")]
        public async Task<ApiResult> ChargeWallet(ChargeWalletCommand command) => CommandResult(await _userFacade.ChargeWallet(command));

        [HttpPut]
        public async Task<ApiResult> Edit(EditUserCommand command) => CommandResult(await _userFacade.Edit(command));

        [HttpPut("changePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordCommand command) => CommandResult(await _userFacade.ChangePassword(command));

        [HttpPut("editAddress")]
        public async Task<ApiResult> EditAddress(EditAddressCommand command) => CommandResult(await _userAddressFacade.Edit(command));

        [HttpDelete("deleteAddress")]
        public async Task<ApiResult> DeleteAddress(DeleteAddressCommand command) => CommandResult(await _userAddressFacade.Delete(command));

    } 
}