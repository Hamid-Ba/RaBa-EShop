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
        public bool IsActive { get; private set; }
        public string Avatar { get; private set; }
        public Gender Gender { get; private set; }

        public List<UserRole> Roles { get; private set; }
        public List<UserWallet> Wallets { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<UserToken> Tokens { get; set; }

        private User() { }

        public User(string firstName, string lastName, string email, string phoneNumber, string password, string avatar,
            Gender gender, IUserDomainService userService)
        {
            GuardByPhoneNumber(phoneNumber, password, userService);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Avatar = avatar;
            Gender = gender;
            IsActive = true;
            Roles = new List<UserRole>();
            Addresses = new List<UserAddress>();
            Tokens = new List<UserToken>();
        }

        public void Edit(string firstName, string lastName, string email, string phoneNumber, string avatar,
            Gender gender, IUserDomainService userService)
        {
            GuardByPhoneNumber(phoneNumber, "ignore", userService);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

            if (!string.IsNullOrWhiteSpace(avatar))
                Avatar = avatar;

            Gender = gender;
        }

        public static User Register(string phoneNumber, string password, IUserDomainService userService) => new User("", "", "", phoneNumber, password, "", Gender.None, userService);

        public void ChangePassword(string newPassword)
        {
            if (!string.IsNullOrWhiteSpace(newPassword))
                Password = newPassword;
        }

        public void Active() => IsActive = true;

        public void DeActive() => IsActive = false;

        #region Address

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void EditAddress(long addressId, UserAddress address)
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

        public void ActiveAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address is null) throw new InvalidDomainDataException("همچین آدرسی وجود ندارد");

            if (Addresses.Any(a => a.IsActive))
                Addresses.Where(a => a.IsActive).FirstOrDefault()?.DeActive();

            address.Active();
        }

        public void DeActiveAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address is null) throw new InvalidDomainDataException("همچین آدرسی وجود ندارد");

            address.DeActive();
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

        #region Wallet

        public void ChargeWallet(UserWallet wallet)
        {
            if (wallet.Amount <= 0)
                throw new InvalidDomainDataException("مبلغ را درست وارد کنید");

            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        #endregion

        #region Token

        public void AddToken(UserToken token)
        {
            var validTokenCount = Tokens.Count(t => t.RefreshTokenExpireDate > DateTime.Now);
            if (validTokenCount ==  3) throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            token.UserId = Id;
            Tokens.Add(token);
        }

        public void RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(t => t.Id == tokenId);
            if(token is null) throw new InvalidDomainDataException("Invalid TokenId");

            Tokens.Remove(token);
        }

        #endregion

        #region Guards

        private void GuardByPhoneNumber(string phoneNumber, string password, IUserDomainService userService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(password, nameof(password));

            if (phoneNumber.Length != 11) throw new InvalidDomainDataException("فرمت شماره همراه درست نمی باشد");

            if (PhoneNumber != phoneNumber)
                if (userService.IsPhoneNumberExist(phoneNumber)) throw new InvalidDomainDataException("همچین شماره همراهی وجود دارد");
        }

        private void GuardByEmail(string email, string password, IUserDomainService userService)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(password, nameof(password));

            if (!EmailValidation.IsValidEmail(email)) throw new InvalidDomainDataException("فرمت ایمیل درست نمی باشد");

            if (Email != email)
                if (userService.IsEmailExist(email)) throw new InvalidDomainDataException("همچین ایمیلی وجود دارد");
        }

        #endregion
    }
}