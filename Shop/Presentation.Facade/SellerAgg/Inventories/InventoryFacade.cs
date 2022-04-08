using Application.SellerAgg.AddInventory;
using Application.SellerAgg.EditInventory;
using Framework.Application;
using MediatR;
using Query.SellerAgg.DTOs;
using Query.SellerAgg.Inventories.GetAll;

namespace Presentation.Facade.SellerAgg.Inventories
{
    public class InventoryFacade : IInventoryFacade
    {
        private readonly IMediator _mediator;

        public InventoryFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddInventory(AddInventoryCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> EditInventory(EditInventoryCommand command) => await _mediator.Send(command);

        public async Task<List<InventoryDto>> GetAllBy(long sellerId) => await _mediator.Send(new GetInventoriesBySellerIdQuery(sellerId));
    }
}