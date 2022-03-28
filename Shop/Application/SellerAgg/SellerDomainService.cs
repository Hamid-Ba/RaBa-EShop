using Domain.SellerAgg.Repository;
using Domain.SellerAgg.Services;

namespace Application.SellerAgg
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerDomainService(ISellerRepository sellerRepository) => _sellerRepository = sellerRepository;

        public bool IsSellerExistWithThis(long userId) => _sellerRepository.Exists(s => s.UserId == userId);

        public bool IsSellerExistWithThis(string nationalCode) => _sellerRepository.Exists(s => s.NationalCode == nationalCode);
        
    }
}