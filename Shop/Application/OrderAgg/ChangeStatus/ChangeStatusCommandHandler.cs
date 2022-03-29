using Domain.OrderAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.ChangeStatus
{
    public class ChangeStatusCommandHandler : IBaseCommandHandler<ChangeStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<OperationResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsTrackingAsyncBy(request.OrderId);
            if (order is null) return OperationResult.NotFound();

            order.ChangeStatus(request.Status);
            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}