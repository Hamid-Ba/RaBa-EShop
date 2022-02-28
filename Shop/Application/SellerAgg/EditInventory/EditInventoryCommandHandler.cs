using Domain.SellerAgg.Repository;
using Framework.Application;

namespace Application.SellerAgg.EditInventory
{
    internal class EditInventoryCommandHandler : IBaseCommandHandler<EditInventoryCommand>
    {
        private readonly ISellerRepository _sellerRepository;

        public EditInventoryCommandHandler(ISellerRepository sellerRepository) => _sellerRepository = sellerRepository;

        public async Task<OperationResult> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetEntityAsyncBy(request.SellerId);
            if (seller is null) return OperationResult.NotFound();

            seller.EditInventory(request.InventoryId, request.ProductId, request.Count, request.Price);
            await _sellerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}