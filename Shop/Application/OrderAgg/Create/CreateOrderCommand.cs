using Framework.Application;

namespace Application.OrderAgg.Create
{
    public record CreateOrderCommand(long UserId) : IBaseCommand;
}