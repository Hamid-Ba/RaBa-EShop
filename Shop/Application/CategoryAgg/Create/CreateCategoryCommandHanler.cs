using Domain.CategoryAgg;
using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;
using Framework.Application;

namespace Application.CategoryAgg.Create
{
    public class CreateCategoryCommandHanler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDomainService _categoryDomainService;

        public CreateCategoryCommandHanler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
        {
            _categoryRepository = categoryRepository;
            _categoryDomainService = categoryDomainService;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _categoryDomainService);
            await _categoryRepository.AddEntityAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
