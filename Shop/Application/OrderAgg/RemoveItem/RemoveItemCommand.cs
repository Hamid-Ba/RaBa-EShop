using Framework.Application;

namespace Application.OrderAgg.RemoveItem
{
    public record RemoveItemCommand(long UserId,long ItemId) : IBaseCommand;
}