using Domain.SellerAgg.Enums;
using Framework.Application;

namespace Application.SellerAgg.ChangeStatus
{
    public record ChangeSellerStatusCommand(long SellerId, SellerStatus SellerStatus, string Description) : IBaseCommand;
}