using Framework.Application;

namespace Application.OrderAgg.ChangeCount
{
    public record ChangeCountCommand(long UserId, long ItemId, long InventoryId, int Count) : IBaseCommand;
}