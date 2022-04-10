using Application.ProductAgg.AddImage;
using Application.ProductAgg.Create;
using Application.ProductAgg.DeleteImage;
using Application.ProductAgg.Edit;
using Application.ProductAgg.EditImage;
using Framework.Application;
using Query.ProductAgg.DTOs;

namespace Presentation.Facade.ProductAgg
{
    public interface IProductFacade
	{
        #region Command
        Task<OperationResult> Edit(EditProductCommand command);
        Task<OperationResult> Create(CreateProductCommand command);
        Task<OperationResult> AddImage(AddImageProductCommand command);
        Task<OperationResult> EditImage(EditImageProductCommand command);
        Task<OperationResult> DeleteImage(DeleteImageProductCommand command);
        #endregion

        #region Query
        Task<ProductDto> GetBy(long id);
        Task<ProductDto> GetBy(string slug);
        Task<ProductFilterResult> GetAll(ProductFilterParam filter);
        Task<ProductShopFilterResult> GetForShop(ProductShopFilterParam filter);
        #endregion
    }
}

