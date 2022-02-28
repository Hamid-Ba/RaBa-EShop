using Framework.Application;

namespace Application.SellerAgg.AddInventory
{
    public record AddInventoryCommand(long SellerId, long ProductId, int Count, double Price) : IBaseCommand;
}