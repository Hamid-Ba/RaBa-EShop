using Domain.SiteEntities;
using Domain.SiteEntities.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.SiteEntities.Repositories
{
    public class BannerRepository : Repository<Banner> , IBannerRepository
	{
		private readonly ShopContext _context;

		public BannerRepository(ShopContext context) : base(context) => _context = context;
		
	}
}