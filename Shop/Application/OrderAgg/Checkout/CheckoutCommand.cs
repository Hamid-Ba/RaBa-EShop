using Framework.Application;

namespace Application.OrderAgg.Checkout
{
    public class CheckoutCommand : IBaseCommand
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }

        public CheckoutCommand(long userId, string fullName, string phoneNumber, string province, string city, string address, string postalCode, string nationalCode)
        {
            UserId = userId;
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