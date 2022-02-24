using Domain.OrderAgg;
using Domain.OrderAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.Create
{
    public class CreateOrderCommandHandler : IBaseCommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<OperationResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.UserId);

            await _orderRepository.AddEntityAsync(order);
            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
