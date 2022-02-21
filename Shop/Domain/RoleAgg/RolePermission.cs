using Domain.RoleAgg.Enums;

namespace Domain.RoleAgg
{
    public class RolePermission
    {
        public long RoleId { get; internal set; }
        public Permission Permission { get; set; }

        public RolePermission(Permission permission) => Permission = permission;
    }
}
