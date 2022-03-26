using Application.CategoryAgg.AddChild;
using Application.CategoryAgg.Create;
using Application.CategoryAgg.Edit;
using Framework.Application;
using Query.CategoryAgg.DTOs;

namespace Presentation.Facade.CategoryAgg
{
    public interface ICategoryFacade
	{
        #region Command
        Task<OperationResult> Edit(EditCategoryCommand command);
		Task<OperationResult> Create(CreateCategoryCommand command);
		Task<OperationResult> AddChild(AddChildCategoryCommand command);
        #endregion

        #region Query
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> GetCategoryById(long id);
        Task<List<CategoryDto>> GetCategoryChildrenById(long parentId);
        #endregion

    }
}