using Domain.OrderAgg;
using Domain.OrderAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.Checkout
{
    public class CheckoutCommandHanler : IBaseCommandHandler<CheckoutCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutCommandHanler(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public async Task<OperationResult> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var openOrder = await _orderRepository.GetUserOpenOrderBy(request.UserId);
            if (openOrder is null) return OperationResult.NotFound();

            var address = new OrderAddress(request.FullName, request.PhoneNumber, request.Province, request.City,
                request.Address, request.PostalCode, request.NationalCode);

            openOrder.Checkout(address);

            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}