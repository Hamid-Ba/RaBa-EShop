using Framework.Query;
using Query.RoleAgg.DTOs;

namespace Query.RoleAgg.Get
{
    public record GetRoleByIdQuery(long Id) : IBaseQuery<RoleDto>;
}