using System;
using Application.SellerAgg.AddInventory;
using Application.SellerAgg.EditInventory;
using Framework.Application;
using Query.SellerAgg.DTOs;

namespace Presentation.Facade.SellerAgg.Inventories
{
	public interface IInventoryFacade
	{
        #region Command
        Task<OperationResult> AddInventory(AddInventoryCommand command);
        Task<OperationResult> EditInventory(EditInventoryCommand command);
        #endregion

        #region Query
        Task<List<InventoryDto>> GetAllBy(long sellerId);
        #endregion
    }
}

