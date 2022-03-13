using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.UserAgg
{
    public class UserRepository : Repository<User> , IUserRepository
	{
		private readonly ShopContext _context;

		public UserRepository(ShopContext context) : base(context) => _context = context;
		
	}
}