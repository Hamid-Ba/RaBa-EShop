using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Inventories.GetAll
{
    public class GetInventoriesBySellerIdQueryHandler : IBaseQueryHandler<GetInventoriesBySellerIdQuery, List<InventoryDto>>
    {
        private readonly ShopContext _context;

        public GetInventoriesBySellerIdQueryHandler(ShopContext context) => _context = context;

        public async Task<List<InventoryDto>> Handle(GetInventoriesBySellerIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == request.SellerId);
            if (seller is null) return new List<InventoryDto>();

            var result = seller.Inventories.ToList().MapInventories(_context);
            result.ForEach(r => r.SellerShopName = seller.ShopName);

            return result;
        }
    }
}