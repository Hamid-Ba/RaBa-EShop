using Framework.Application;

namespace Application.UserAgg.DeleteAddress
{
    public record DeleteAddressCommand(long UserId, long AddressId) : IBaseCommand;
}