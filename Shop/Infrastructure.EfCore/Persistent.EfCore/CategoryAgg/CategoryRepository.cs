using Domain.CategoryAgg;
using Domain.CategoryAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.CategoryAgg
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
	{
		private readonly ShopContext _context;

		public CategoryRepository(ShopContext context) : base(context) => _context = context;
		
	}
}