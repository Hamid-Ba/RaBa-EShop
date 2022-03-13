using Domain.RoleAgg;
using Domain.RoleAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.RoleAgg
{
    public class RoleRepository : Repository<Role> , IRoleRepository
	{
		private readonly ShopContext _context;

		public RoleRepository(ShopContext context) : base(context) => _context = context;
		
	}
}