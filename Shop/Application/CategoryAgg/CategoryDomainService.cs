using Domain.CategoryAgg.Services;

namespace Application.CategoryAgg
{
    public class CategoryDomainService : ICategoryDomainService
	{
        public Task<bool> IsSlugExist(string slug)
        {
            throw new NotImplementedException();
        }
    }
}