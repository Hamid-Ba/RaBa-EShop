using Domain.OrderAgg.Repository;
using Domain.SellerAgg.Repository;
using Framework.Application;

namespace Application.OrderAgg.ChangeCount
{
    public class ChangeCountCommandHandler : IBaseCommandHandler<ChangeCountCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISellerRepository _sellerRepository;

        public ChangeCountCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
        {
            _orderRepository = orderRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(ChangeCountCommand request, CancellationToken cancellationToken)
        {
            var openOrder = await _orderRepository.GetUserOpenOrderBy(request.UserId);
            if (openOrder is null) return OperationResult.NotFound();

            var inventory = await _sellerRepository.GetInventoryBy(request.InventoryId);
            if (inventory.Count < request.Count) throw new InvalidOperationException("تعداد محصول انتخاب شده بیشتر از موجودی انبار هست");

            openOrder.ChangeCount(request.ItemId, request.Count);
            await _orderRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}