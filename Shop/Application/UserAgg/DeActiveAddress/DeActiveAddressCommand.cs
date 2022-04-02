using Framework.Application;

namespace Application.UserAgg.DeActiveAddress
{
    public class DeActiveAddressCommand : IBaseCommand
	{
        public long UserId { get; set; }
        public long AddressId { get; private set; }

		public DeActiveAddressCommand(long addressId) => AddressId = addressId;
	}
}