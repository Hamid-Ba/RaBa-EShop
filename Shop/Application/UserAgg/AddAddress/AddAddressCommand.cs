using Framework.Application;

namespace Application.UserAgg.AddAddress
{
    public record AddAddressCommand(long UserId,string FullName, string PhoneNumber, string Province, string City, string Address,
			string PostalCode, string NationalCode) : IBaseCommand;
}