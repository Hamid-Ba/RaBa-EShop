using Application.OrderAgg.AddItem;
using Application.OrderAgg.ChangeCount;
using Application.OrderAgg.ChangeStatus;
using Application.OrderAgg.Checkout;
using Application.OrderAgg.Create;
using Application.OrderAgg.RemoveItem;
using Framework.Application;
using Query.OrderAgg.DTOs;

namespace Presentation.Facade.OrderAgg
{
    public interface IOrderFacade
	{
        #region Command
        Task<OperationResult> AddItem(AddItemCommand command);
		Task<OperationResult> Checkout(CheckoutCommand command);
		Task<OperationResult> Create(CreateOrderCommand command);
		Task<OperationResult> RemoveItem(RemoveItemCommand command);
		Task<OperationResult> ChangeCount(ChangeCountCommand command);
		Task<OperationResult> ChangeStatus(ChangeStatusCommand command);
		#endregion

		#region Query
		Task<OrderDto> GetBy(long orderId);
		Task<List<OrderItemDto>> GetItemsBy(long orderId);
		Task<OrderFilterResult> GetAll(OrderFilterParam filter);
        #endregion
    }
}

