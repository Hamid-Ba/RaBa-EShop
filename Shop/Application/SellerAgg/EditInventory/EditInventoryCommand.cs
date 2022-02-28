using Framework.Application;

namespace Application.SellerAgg.EditInventory
{
    public record EditInventoryCommand(long SellerId, long InventoryId, long ProductId, int Count, double Price) : IBaseCommand;
}