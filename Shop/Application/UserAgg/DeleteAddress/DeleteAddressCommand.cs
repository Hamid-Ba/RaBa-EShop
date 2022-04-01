using Framework.Application;

namespace Application.UserAgg.DeleteAddress
{
    public class DeleteAddressCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public long AddressId { get;private set; }

        public DeleteAddressCommand(long addressId) => AddressId = addressId;
    }
}