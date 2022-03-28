using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;

namespace Application.CategoryAgg
{
    public class CategoryDomainService : ICategoryDomainService
	{
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDomainService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public bool IsSlugExist(string slug) => _categoryRepository.Exists(c => c.Slug == slug);
        
    }
}