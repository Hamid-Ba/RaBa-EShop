using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.RoleAgg.DTOs;

namespace Query.RoleAgg.GetAll
{
    public class GetAllRolesQueryHandler : IBaseQueryHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly ShopContext _context;

        public GetAllRolesQueryHandler(ShopContext context) => _context = context;

        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => r.Map()).ToList();
        }
    }
}