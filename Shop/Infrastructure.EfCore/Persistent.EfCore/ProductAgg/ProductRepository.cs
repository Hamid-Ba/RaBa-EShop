using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.ProductAgg
{
    public class ProductRepository : Repository<Product> , IProductRepository
	{
		private readonly ShopContext _context;

		public ProductRepository(ShopContext context) : base(context) => _context = context;
		
	}
}