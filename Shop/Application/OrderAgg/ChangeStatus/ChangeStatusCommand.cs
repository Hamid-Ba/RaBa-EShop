using Domain.OrderAgg.Enums;
using Framework.Application;

namespace Application.OrderAgg.ChangeStatus
{
    public record ChangeStatusCommand(long OrderId, OrderStatus Status) : IBaseCommand;
}