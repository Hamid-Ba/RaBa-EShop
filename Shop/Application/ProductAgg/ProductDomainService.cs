using Domain.ProductAgg.Repository;
using Domain.ProductAgg.Services;

namespace Application.ProductAgg
{
    public class ProductDomainService : IProductDomainService
	{
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository) => _productRepository = productRepository;

        public bool IsSlugExist(string slug) => _productRepository.Exists(p => p.Slug == slug);
        
    }
}