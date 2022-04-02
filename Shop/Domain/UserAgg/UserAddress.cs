using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public long UserId { get; internal set; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string NationalCode { get; private set; }
        public bool IsActive { get; private set; }

        public UserAddress(string fullName, string phoneNumber, string province, string city, string address,
            string postalCode, string nationalCode)
        {
            Guard(fullName,phoneNumber,province, city, address, postalCode, nationalCode);

            FullName = fullName;
            PhoneNumber = phoneNumber;
            Province = province;
            City = city;
            Address = address;
            PostalCode = postalCode;
            NationalCode = nationalCode;
            IsActive = false;
        }

        public void Edit(string fullName, string phoneNumber, string province, string city, string address,
             string postalCode, string nationalCode)
        {
            Guard(fullName, phoneNumber, province, city, address, postalCode, nationalCode);

            FullName = fullName;
            PhoneNumber = phoneNumber;
            Province = province;
            City = city;
            Address = address;
            PostalCode = postalCode;
            NationalCode = nationalCode;
            IsActive = false;
        }

        public void Active() => IsActive = true;

        public void DeActive() => IsActive = false;

        private void Guard(string fullName, string phoneNumber, string province, string city, string address,
            string postalCode, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(fullName, nameof(fullName));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(province, nameof(province));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(address, nameof(address));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (phoneNumber.Length != 11) throw new InvalidDomainDataException("فرمت تلفن همراه درست نمی باشد");

            if (!IranianNationalIdChecker.IsValid(nationalCode)) throw new InvalidDomainDataException("فرمت کد ملی درست نمی باشد");
        }

    }
}