using Application.OrderAgg.AddItem;
using Application.OrderAgg.ChangeCount;
using Application.OrderAgg.ChangeStatus;
using Application.OrderAgg.Checkout;
using Application.OrderAgg.Create;
using Application.OrderAgg.RemoveItem;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.OrderAgg;
using Query.OrderAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    [Authorize]
    public class OrderController : BaseApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade) => _orderFacade = orderFacade;

        [HttpGet]
        [PermissionChecker(Permission.Order_Management)]
        public async Task<ApiResult<OrderFilterResult>> GetAll([FromQuery]OrderFilterParam param) => QueryResult(await _orderFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<OrderDto>> Get(long id) => QueryResult(await _orderFacade.GetBy(id));

        [HttpGet("items/{id}")]
        public async Task<ApiResult<List<OrderItemDto>>> GetItems(long id) => QueryResult(await _orderFacade.GetItemsBy(id));

        [HttpPost]
        public async Task<ApiResult> Create(CreateOrderCommand command) => CommandResult(await _orderFacade.Create(command));

        [HttpPost("checkout")]
        public async Task<ApiResult> Checkout(CheckoutCommand command) => CommandResult(await _orderFacade.Checkout(command));

        [HttpPost("AddItem")]
        public async Task<ApiResult> AddItem(AddItemCommand command) => CommandResult(await _orderFacade.AddItem(command));

        [HttpPut("changeItemCount")]
        public async Task<ApiResult> ChangeItemCount(ChangeCountCommand command) => CommandResult(await _orderFacade.ChangeCount(command));

        [HttpPut("changeStatus")]
        public async Task<ApiResult> ChangeStatus(ChangeStatusCommand command) => CommandResult(await _orderFacade.ChangeStatus(command));

        [HttpPut("removeItem")]
        public async Task<ApiResult> RemoveItem(RemoveItemCommand command) => CommandResult(await _orderFacade.RemoveItem(command));
    }
}