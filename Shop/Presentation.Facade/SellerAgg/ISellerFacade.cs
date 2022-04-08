using Application.SellerAgg.AddInventory;
using Application.SellerAgg.ChangeStatus;
using Application.SellerAgg.Create;
using Application.SellerAgg.Edit;
using Application.SellerAgg.EditInventory;
using Framework.Application;
using Query.SellerAgg.DTOs;

namespace Presentation.Facade.SellerAgg
{
    public interface ISellerFacade
	{
        #region Command
        Task<OperationResult> Edit(EditSellerCommand command);
        Task<OperationResult> Create(CreateSellerCommand command);
        Task<OperationResult> AddInventory(AddInventoryCommand command);
        Task<OperationResult> EditInventory(EditInventoryCommand command);
        Task<OperationResult> ChangeStatus(ChangeSellerStatusCommand command);
        #endregion

        #region Query
        Task<SellerDto> GetBy(long id);
        Task<SellerDto> GetByCurrentUser(long userId);
        Task<SellerFilterResult> GetAll(SellerFilterParam filter);
        #endregion
    }
}