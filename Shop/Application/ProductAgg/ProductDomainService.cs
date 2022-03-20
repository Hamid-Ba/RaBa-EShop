using Domain.ProductAgg.Services;

namespace Application.ProductAgg
{
    public class ProductDomainService : IProductDomainService
	{
        public Task<bool> IsSlugExist(string slug)
        {
            throw new NotImplementedException();
        }
    }
}