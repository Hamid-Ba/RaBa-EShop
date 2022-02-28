using Domain.RoleAgg.Enums;
using Framework.Application;

namespace Application.RoleAgg.Create
{
    public record CreateRoleCommand(string Title, string Description, List<Permission> Permissions) : IBaseCommand;
}