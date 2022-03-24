using Domain.RoleAgg;
using Query.RoleAgg.DTOs;

namespace Query.RoleAgg
{
    public static class RoleMapper
	{
		public static RoleDto Map(this Role role)
        {
			return new RoleDto
			{
				Id = role.Id,
				Title = role.Title,
				Permissions = role.Permissions.Select(p => p.Permission).ToList(),
				Description = role.Description
			};
        }
	}
}