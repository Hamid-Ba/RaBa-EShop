using Domain.CategoryAgg;
using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;
using Framework.Application;

namespace Application.CategoryAgg.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDomainService _categoryDomainService;

        public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
        {
            _categoryRepository = categoryRepository;
            _categoryDomainService = categoryDomainService;
        }

        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetEntityAsyncBy(request.ParentId);
            if (category is null) OperationResult.NotFound();

            var child = new Category(request.Title, request.Slug, request.SeoData, _categoryDomainService);
            category.AddChild(child);

            await _categoryRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}
