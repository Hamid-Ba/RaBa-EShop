using System;
using Framework.Application;

namespace Application.UserAgg.EditAddress
{
    public record EditAddressCommand(long UserId,long AddressId, string FullName, string PhoneNumber, string Province, string City, string Address,
			string PostalCode, string NationalCode) : IBaseCommand;
}