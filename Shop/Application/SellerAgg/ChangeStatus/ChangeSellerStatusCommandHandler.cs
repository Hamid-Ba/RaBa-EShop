using Domain.SellerAgg.Repository;
using Framework.Application;

namespace Application.SellerAgg.ChangeStatus
{
    internal class ChangeSellerStatusCommandHandler : IBaseCommandHandler<ChangeSellerStatusCommand>
    {
        private readonly ISellerRepository _sellerRepository;

        public ChangeSellerStatusCommandHandler(ISellerRepository sellerRepository) => _sellerRepository = sellerRepository;

        public async Task<OperationResult> Handle(ChangeSellerStatusCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetAsTrackingAsyncBy(request.SellerId);
            if (seller is null) return OperationResult.NotFound();

            seller.ChangeStatus(request.SellerStatus, request.Description);
            await _sellerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}