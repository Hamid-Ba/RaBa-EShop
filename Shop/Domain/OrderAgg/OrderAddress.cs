using Framework.Domain;

namespace Domain.OrderAgg
{
    public class OrderAddress : BaseEntity
    {
        public long OrderId { get; internal set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string NationalCode { get; private set; }

        public Order Order { get; private set; }

        public OrderAddress(string fullName, string phoneNumber, string province, string city, string address, string postalCode, string nationalCode)
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
