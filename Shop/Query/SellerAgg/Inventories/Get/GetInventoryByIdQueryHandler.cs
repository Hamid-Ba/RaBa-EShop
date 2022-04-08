using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Inventories.Get
{
    public class GetInventoryByIdQueryHandler : IBaseQueryHandler<GetInventoryByIdQuery, InventoryDto>
    {
        private readonly ShopContext _context;

        public GetInventoryByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Inventories.Any(i => i.Id == request.Id));
            if (seller is null) return new InventoryDto();

            var result = seller.Inventories.FirstOrDefault(i => i.Id == request.Id)?.MapInventory(_context);
            result.SellerShopName = seller.ShopName;

            return result;
        }
    }
}