using Domain.SellerAgg;
using Domain.SellerAgg.Repository;
using Domain.SellerAgg.Services;
using Framework.Application;

namespace Application.SellerAgg.Create
{
    internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ISellerDomainService _sellerDomainService;

        public CreateSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService sellerDomainService)
        {
            _sellerRepository = sellerRepository;
            _sellerDomainService = sellerDomainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _sellerDomainService);
            await _sellerRepository.AddEntityAsync(seller);

            await _sellerRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}