using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.RoleAgg.DTOs;

namespace Query.RoleAgg.Get
{
    public class GetRoleByIdQueryHandler : IBaseQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly ShopContext _context;

        public GetRoleByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.Id);
            if (role is null) return null;

            return role.Map();
        }
    }
}