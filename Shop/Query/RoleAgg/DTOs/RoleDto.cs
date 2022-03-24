using Domain.RoleAgg.Enums;
using Framework.Query;

namespace Query.RoleAgg.DTOs
{
    public class RoleDto : BaseDto
	{
		public string Title { get;  set; }
		public string Description { get; set; }

		public List<Permission> Permissions { get; set; }
	}
}