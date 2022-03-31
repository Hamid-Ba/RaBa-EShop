using Application.SellerAgg.AddInventory;
using Application.SellerAgg.ChangeStatus;
using Application.SellerAgg.Create;
using Application.SellerAgg.Edit;
using Application.SellerAgg.EditInventory;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SellerAgg;
using Query.SellerAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class SellerController : BaseApiController
    {
        private readonly ISellerFacade _sellerFacade;

        public SellerController(ISellerFacade sellerFacade) => _sellerFacade = sellerFacade;

        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetAll([FromQuery] SellerFilterParam param) => QueryResult(await _sellerFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto>> GetBy(long id) => QueryResult(await _sellerFacade.GetBy(id));

        [HttpPost]
        public async Task<ApiResult> Create(CreateSellerCommand command) => CommandResult(await _sellerFacade.Create(command));

        [HttpPost("addInventory")]
        public async Task<ApiResult> AddInventory(AddInventoryCommand command) => CommandResult(await _sellerFacade.AddInventory(command));

        [HttpPut]
        public async Task<ApiResult> Edit(EditSellerCommand command) => CommandResult(await _sellerFacade.Edit(command));

        [HttpPut("editInventory")]
        public async Task<ApiResult> EditInventory(EditInventoryCommand command) => CommandResult(await _sellerFacade.EditInventory(command));

        [HttpPut("changeStatus")]
        public async Task<ApiResult> ChangeStatus(ChangeSellerStatusCommand command) => CommandResult(await _sellerFacade.ChangeStatus(command));
    }
}