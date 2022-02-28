using Domain.SellerAgg.Repository;
using Domain.SellerAgg.Services;
using Framework.Application;

namespace Application.SellerAgg.Edit
{
    internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ISellerDomainService _sellerDomainService;

        public EditSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService sellerDomainService)
        {
            _sellerRepository = sellerRepository;
            _sellerDomainService = sellerDomainService;
        }

        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetEntityAsyncBy(request.SellerId);
            if (seller is null) return OperationResult.NotFound();

            seller.Edit(request.ShopName, request.NationalCode, _sellerDomainService);
            await _sellerRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}