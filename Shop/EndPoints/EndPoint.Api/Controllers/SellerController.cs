using Application.SellerAgg.AddInventory;
using Application.SellerAgg.ChangeStatus;
using Application.SellerAgg.Create;
using Application.SellerAgg.Edit;
using Application.SellerAgg.EditInventory;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Framework.Presentation.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SellerAgg;
using Presentation.Facade.SellerAgg.Inventories;
using Query.SellerAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class SellerController : BaseApiController
    {
        private readonly ISellerFacade _sellerFacade;
        private readonly IInventoryFacade _inventoryFacade;

        public SellerController(ISellerFacade sellerFacade, IInventoryFacade inventoryFacade)
        {
            _sellerFacade = sellerFacade;
            _inventoryFacade = inventoryFacade;
        }

        [HttpGet]
        [PermissionChecker(Permission.Seller_Management)]
        public async Task<ApiResult<SellerFilterResult>> GetAll([FromQuery] SellerFilterParam param) => QueryResult(await _sellerFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto>> GetBy(long id) => QueryResult(await _sellerFacade.GetBy(id));

        [Authorize]
        [HttpGet("getByCurrentUser")]
        public async Task<ApiResult<SellerDto>> GetByCurrentUser() => QueryResult(await _sellerFacade.GetByCurrentUser(User.GetUserId()));

        [HttpGet("getAllInventories")]
        public async Task<ApiResult<List<InventoryDto>>> GetAllInventories() => QueryResult(await _inventoryFacade.GetAllBy(User.GetUserId()));

        [HttpGet("getInventory/{inventoryId}")]
        public async Task<ApiResult<InventoryDto>> GetInventory(long inventoryId)
        {
            var seller = await _sellerFacade.GetByCurrentUser(User.GetUserId());

            var result = await _inventoryFacade.GetBy(inventoryId);

            if (result is null || result.SellerId != seller.Id)
                return QueryResult(new InventoryDto());

            return QueryResult(result);
        }

        [HttpPost]
        [PermissionChecker(Permission.Seller_Management)]
        public async Task<ApiResult> Create(CreateSellerCommand command) => CommandResult(await _sellerFacade.Create(command));

        [HttpPost("addInventory")]
        [PermissionChecker(Permission.Add_Inventory)]
        public async Task<ApiResult> AddInventory(AddInventoryCommand command) => CommandResult(await _inventoryFacade.AddInventory(command));

        [HttpPut]
        [PermissionChecker(Permission.Seller_Management)]
        public async Task<ApiResult> Edit(EditSellerCommand command) => CommandResult(await _sellerFacade.Edit(command));

        [HttpPut("editInventory")]
        [PermissionChecker(Permission.Edit_Inventory)]
        public async Task<ApiResult> EditInventory(EditInventoryCommand command) => CommandResult(await _inventoryFacade.EditInventory(command));

        [HttpPut("changeStatus")]
        [PermissionChecker(Permission.Seller_Management)]
        public async Task<ApiResult> ChangeStatus(ChangeSellerStatusCommand command) => CommandResult(await _sellerFacade.ChangeStatus(command));
    }
}