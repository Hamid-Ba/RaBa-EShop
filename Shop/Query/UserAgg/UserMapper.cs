using Domain.UserAgg;
using Infrastructure.Persistent.EfCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg
{
    public static class UserMapper
    {
        public static UserDto MapSingle(this User user, ShopContext context)
        {
            if (user is null) return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Avatar = user.Avatar,
                CreationDate = user.CreationDate,
                Roles = MapRoles(user.Roles, context),
                IsDelete = user.IsDelete,
                DeleteDate = user.DeleteDate,
                Password = user.Password,
                IsActive = user.IsActive
            };
        }

        public static UserFilterDto Map(this User user,ShopContext context)
        {
            if (user is null) return null;

            return new UserFilterDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Avatar = user.Avatar,
                CreationDate = user.CreationDate,
                Roles = MapRoles(user.Roles, context),
                IsDelete = user.IsDelete,
                DeleteDate = user.DeleteDate,
                IsActive = user.IsActive
            };
        }

        public static List<UserFilterDto> MapList(this List<User> users,ShopContext context) => users.Select(u => new UserFilterDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            Gender = u.Gender,
            Avatar = u.Avatar,
            CreationDate = u.CreationDate,
            Roles = MapRoles(u.Roles, context),
            IsDelete = u.IsDelete,
            DeleteDate = u.DeleteDate,
            IsActive = u.IsActive
        }).ToList();

        private static List<UserRoleDto> MapRoles(List<UserRole> roles, ShopContext context)
        {
            if (roles.Count == 0) return new();

            var rolesList = context.Roles.Select(r => new UserRoleDto { RoleId = r.Id, RoleTitle = r.Title }).ToList();

            var userRoles = new List<UserRoleDto>();

            foreach (var role in rolesList)
            {
                foreach (var userRole in roles)
                    if (role.RoleId == userRole.Id)
                        userRoles.Add(role);
            }

            return userRoles;
        }

        public static UserAddressDto MapAddress(this UserAddress address)
        {
            if (address is null) return new UserAddressDto();

            return new UserAddressDto
            {
                Id = address.Id,
                UserId = address.UserId,
                Province = address.Province,
                City = address.City,
                Address = address.Address,
                PostalCode = address.PostalCode,
                PhoneNumber = address.PhoneNumber,
                NationalCode = address.NationalCode,
                FullName = address.FullName,
                IsActive = address.IsActive,
                CreationDate = address.CreationDate
            };
        }

        public static UserTokenDto? MapToken(this UserToken token) => new UserTokenDto
        {
            Id = token.Id,
            UserId = token.UserId,
            HashToken = token.HashToken,
            HashRefreshToken = token.HashRefreshToken,
            TokenExpireDate = token.TokenExpireDate,
            RefreshTokenExpireDate = token.RefreshTokenExpireDate,
            Device = token.Device
        };
    }
}