using Domain.CategoryAgg.Repository;
using Domain.CategoryAgg.Services;
using Framework.Application;

namespace Application.CategoryAgg.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDomainService _categoryDomainService;

        public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
        {
            _categoryRepository = categoryRepository;
            _categoryDomainService = categoryDomainService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsTrackingAsyncBy(request.id);
            if (category is null) return OperationResult.NotFound();

            category.Edit(request.Title, request.Slug, request.SeoData, _categoryDomainService);
            await _categoryRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}