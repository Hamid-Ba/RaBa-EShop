using Framework.Application;

namespace Application.UserAgg.ActiveAddress
{
    public class ActiveAddressCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public long AddressId { get;private set; }

        public ActiveAddressCommand(long addressId) => AddressId = addressId;
    }
}