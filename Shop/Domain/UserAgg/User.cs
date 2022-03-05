using Domain.UserAgg.Enums;
using Domain.UserAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Avatar { get; private set; }
        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; private set; }
        public List<UserAddress> Addresses { get; private set; }

        public User(string firstName, string lastName, string email, string phoneNumber, string password, string avatar,
            Gender gender,List<UserRole> roles, IUserDomainService userService)
        {
            GuardByPhoneNumber(phoneNumber, password, userService);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Avatar = avatar;
            Gender = gender;
            Roles = roles;
            Addresses = new List<UserAddress>();
        }

        public void Edit(string firstName, string lastName, string email, string phoneNumber, string password, string avatar,
            Gender gender, IUserDomainService userService)
        {
            GuardByPhoneNumber(phoneNumber, "ignore", userService);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

            if (!string.IsNullOrWhiteSpace(password))
                Password = password;

            if (!string.IsNullOrWhiteSpace(avatar))
                Avatar = avatar;

            Gender = gender;
        }

        public static User Register(string phoneNumber, string password, IUserDomainService userService) => new User("", "", "", phoneNumber, password, "", Gender.None,new List<UserRole>(), userService);


        #region Address

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void EditAddress(long addressId,UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);

            if (oldAddress is null) throw new InvalidDomainDataException("همچین آدرسی وجود ندارد");

            oldAddress.Edit(address.FullName, address.PhoneNumber, address.Province, address.City, address.Address,
                address.PostalCode, address.NationalCode);
        }

        public void DeleteAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address is null) throw new InvalidDomainDataException("همچین آدرسی وجود ندارد");

            Addresses.Remove(address);
        }

        #endregion

        #region Roles

        public void SetRoles(List<UserRole> roles)
        {
            Roles?.Clear();

            roles.ForEach(r => r.UserId = Id);

            Roles?.AddRange(roles);
        }

        #endregion

        #region Guards

        private async void GuardByPhoneNumber(string phoneNumber, string password, IUserDomainService userService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(password, nameof(password));

            if (phoneNumber.Length != 11) throw new InvalidDomainDataException("فرمت شماره همراه درست نمی باشد");

            if (PhoneNumber != phoneNumber)
                if (await userService.IsPhoneNumberExist(phoneNumber)) throw new InvalidDomainDataException("همچین شماره همراهی وجود دارد");
        }

        private async void GuardByEmail(string email, string password, IUserDomainService userService)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(password, nameof(password));

            if (!EmailValidation.IsValidEmail(email)) throw new InvalidDomainDataException("فرمت ایمیل درست نمی باشد");

            if (Email != email)
                if (await userService.IsEmailExist(email)) throw new InvalidDomainDataException("همچین ایمیلی وجود دارد");
        }

        #endregion


    }
}