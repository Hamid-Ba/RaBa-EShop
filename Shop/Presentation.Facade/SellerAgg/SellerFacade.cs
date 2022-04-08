using Application.SellerAgg.AddInventory;
using Application.SellerAgg.ChangeStatus;
using Application.SellerAgg.Create;
using Application.SellerAgg.Edit;
using Application.SellerAgg.EditInventory;
using Framework.Application;
using MediatR;
using Query.SellerAgg.DTOs;
using Query.SellerAgg.Get;
using Query.SellerAgg.GetAll;
using Query.SellerAgg.GetBy;

namespace Presentation.Facade.SellerAgg
{
    public class SellerFacade : ISellerFacade
	{
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddInventory(AddInventoryCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangeStatus(ChangeSellerStatusCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateSellerCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditSellerCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> EditInventory(EditInventoryCommand command) => await _mediator.Send(command);

        public async Task<SellerFilterResult> GetAll(SellerFilterParam filter) => await _mediator.Send(new GetAllSellerQuery(filter));

        public async Task<SellerDto> GetBy(long id) => await _mediator.Send(new GetSellerByIdQuery(id));

        public async Task<SellerDto> GetByCurrentUser(long userId) => await _mediator.Send(new GetSellerByUserIdQuery(userId));
        
    }
}