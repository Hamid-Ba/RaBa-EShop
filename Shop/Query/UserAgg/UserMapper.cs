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
                DeleteDate = user.DeleteDate
            };
        }

        public static UserFilterDto Map(this User user, ShopContext context)
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
                DeleteDate = user.DeleteDate
            };
        }

        private static List<UserRoleDto> MapRoles(List<UserRole> roles, ShopContext context)
        {
            if (roles is null) return null;

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
    }
}