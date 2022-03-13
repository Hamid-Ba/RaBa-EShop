using Application.Contract.SellerAgg;
using Domain.SellerAgg;
using Domain.SellerAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.SellerAgg
{
    public class SellerRepository : Repository<Seller> , ISellerRepository
	{
		private readonly ShopContext _context;

		public SellerRepository(ShopContext context) : base(context) => _context = context;

        public Task<InventoryDto> GetInventoryBy(long id)
        {
            throw new NotImplementedException();
        }
    }
}