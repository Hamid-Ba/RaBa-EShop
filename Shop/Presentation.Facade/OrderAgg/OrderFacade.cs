using Application.OrderAgg.AddItem;
using Application.OrderAgg.ChangeCount;
using Application.OrderAgg.ChangeStatus;
using Application.OrderAgg.Checkout;
using Application.OrderAgg.Create;
using Application.OrderAgg.RemoveItem;
using Framework.Application;
using MediatR;
using Query.OrderAgg.DTOs;
using Query.OrderAgg.Get;
using Query.OrderAgg.GetAll;
using Query.OrderAgg.GetItems;

namespace Presentation.Facade.OrderAgg
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddItem(AddItemCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangeCount(ChangeCountCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> ChangeStatus(ChangeStatusCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Checkout(CheckoutCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateOrderCommand command) => await _mediator.Send(command);

        public async Task<OrderFilterResult> GetAll(OrderFilterParam filter) => await _mediator.Send(new GetAllOrderQuery(filter));

        public async Task<OrderDto> GetBy(long orderId) => await _mediator.Send(new GetOrderByIdQuery(orderId));

        public async Task<List<OrderItemDto>> GetItemsBy(long orderId) => await _mediator.Send(new GetItemsByIdQuery(orderId));

        public async Task<OperationResult> RemoveItem(RemoveItemCommand command) => await _mediator.Send(command);
    }
}