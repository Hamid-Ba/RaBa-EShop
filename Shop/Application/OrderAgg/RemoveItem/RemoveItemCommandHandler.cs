using Domain.OrderAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.RemoveItem
{
    public class RemoveItemCommandHandler : IBaseCommandHandler<RemoveItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveItemCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<OperationResult> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var openOrder = await _orderRepository.GetUserOpenOrderBy(request.UserId);
            if (openOrder is null) return OperationResult.NotFound();

            openOrder.RemoveItem(request.ItemId);
            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}