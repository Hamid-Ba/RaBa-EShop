using Domain.RoleAgg.Enums;
using Framework.Application;

namespace Application.RoleAgg.Edit
{
    public record EditRoleCommand(long Id,string Title, string Description,List<Permission> Permissions) : IBaseCommand;
}