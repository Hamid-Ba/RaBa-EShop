using Framework.Application;

namespace Application.OrderAgg.AddItem
{
    public record AddItemCommand(long UserId,long InventoryId,int Count) : IBaseCommand;
}
