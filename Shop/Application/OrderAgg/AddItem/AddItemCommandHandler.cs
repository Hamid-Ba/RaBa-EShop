using Domain.OrderAgg;
using Domain.OrderAgg.Repository;
using Domain.SellerAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.AddItem
{
    public class AddItemCommandHandler : IBaseCommandHandler<AddItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISellerRepository _sellerRepository;

        public AddItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
        {
            _orderRepository = orderRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var openOrder = await _orderRepository.GetUserOpenOrderBy(request.UserId);
            if (openOrder is null) openOrder = new Order(request.UserId);

            var inventory = await _sellerRepository.GetInventoryBy(request.InventoryId);
            if (inventory.Count < request.Count) throw new InvalidOperationException("تعداد محصول انتخاب شده بیشتر از موجودی انبار هست");

            openOrder.AddItem(new OrderItem(openOrder.Id, request.InventoryId, request.Count));
            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}