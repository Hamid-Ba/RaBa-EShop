using Framework.Application;

namespace Application.UserAgg.AddAddress
{
    public class AddAddressCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string NationalCode { get; private set; }

        public AddAddressCommand(string fullName, string phoneNumber, string province, string city,
            string address, string postalCode, string nationalCode)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Province = province;
            City = city;
            Address = address;
            PostalCode = postalCode;
            NationalCode = nationalCode;
        }
    }

}