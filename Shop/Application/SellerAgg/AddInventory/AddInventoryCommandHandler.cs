using Domain.SellerAgg;
using Domain.SellerAgg.Repository;
using Framework.Application;

namespace Application.SellerAgg.AddInventory
{
    internal class AddInventoryCommandHandler : IBaseCommandHandler<AddInventoryCommand>
    {
        private readonly ISellerRepository _sellerRepository;

        public AddInventoryCommandHandler(ISellerRepository sellerRepository) => _sellerRepository = sellerRepository;

        public async Task<OperationResult> Handle(AddInventoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetEntityAsyncBy(request.SellerId);
            if (seller is null) return OperationResult.NotFound();

            var inventory = new Inventory(request.ProductId, request.Count, request.Price);
            seller.AddInventory(inventory);

            await _sellerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
