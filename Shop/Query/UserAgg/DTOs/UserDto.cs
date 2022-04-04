using Domain.UserAgg.Enums;
using Framework.Query;
using Framework.Query.Filter;

namespace Query.UserAgg.DTOs
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }

        public List<UserRoleDto> Roles { get; set; }
        public List<UserWalletDto> Wallets { get; set; }
        public List<UserAddressDto> Addresses { get; set; }
    }

    public class UserRoleDto
    {
        public long RoleId { get; set; }
        public string RoleTitle { get; set; }
    }

    public class UserAddressDto : BaseDto
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class UserTokenDto : BaseDto
    {
        public long UserId { get; set; }
        public string HashToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public string Device { get; set; }
    }

    public class UserWalletDto : BaseDto
    {
        public long UserId { get; set; }
        public double Amount { get; set; }
        public WalletType Type { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedDate { get; set; }
        public string RefId { get; set; }
    }

    public class UserFilterDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }

        public List<UserRoleDto> Roles { get; set; }
    }

    public class UserFilterParam : BaseFilterParam
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class UserFilterResult : BaseFilter<UserFilterDto, UserFilterParam>
    {
        public UserFilterResult(List<UserFilterDto> data, UserFilterParam filterParams) : base(data, filterParams)
        {
        }
    }
}