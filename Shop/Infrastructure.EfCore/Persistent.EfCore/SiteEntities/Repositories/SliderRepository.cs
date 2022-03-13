using Domain.SiteEntities;
using Domain.SiteEntities.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.SiteEntities.Repositories
{
    public class SliderRepository : Repository<Slider> , ISliderRepository
	{
		private readonly ShopContext _context;

		public SliderRepository(ShopContext context) : base(context) => _context = context;
		
	}
}