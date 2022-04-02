using Application.UserAgg.ActiveAddress;
using Application.UserAgg.AddAddress;
using Application.UserAgg.DeActiveAddress;
using Application.UserAgg.DeleteAddress;
using Application.UserAgg.EditAddress;
using Framework.Presentation.Api;
using Framework.Presentation.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.UserAgg.UserAddress;
using Query.UserAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    [Authorize]
    public class UserAddressController : BaseApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;

        public UserAddressController(IUserAddressFacade userAddressFacade) => _userAddressFacade = userAddressFacade;

        [HttpGet("{userId}")]
        public async Task<ApiResult<List<UserAddressDto>>> GetAll(long userId) => QueryResult(await _userAddressFacade.GetAllBy(userId));

        [HttpGet("{userId}/{id}")]
        public async Task<ApiResult<UserAddressDto>> GetBy(long userId, long id) => QueryResult(await _userAddressFacade.GetBy(userId, id));

        [HttpPost]
        public async Task<ApiResult> AddAddress(AddAddressCommand command)
        {
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.Add(command));
        }

        [HttpPut]
        public async Task<ApiResult> EditAddress(EditAddressCommand command)
        {
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.Edit(command));
        }

        [HttpPut("active")]
        public async Task<ApiResult> ActiveAddress(ActiveAddressCommand command)
        {
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.Active(command));
        }

        [HttpPut("deActive")]
        public async Task<ApiResult> DeActiveAddress(DeActiveAddressCommand command)
        {
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.DeActive(command));
        }

        [HttpDelete]
        public async Task<ApiResult> DeleteAddress(DeleteAddressCommand command)
        {
            command.UserId = User.GetUserId();
            return CommandResult(await _userAddressFacade.Delete(command));
        }
    }
}