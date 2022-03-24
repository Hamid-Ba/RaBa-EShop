using Framework.Query;
using Query.RoleAgg.DTOs;

namespace Query.RoleAgg.GetAll
{
    public record GetAllRolesQuery : IBaseQuery<List<RoleDto>>;
}