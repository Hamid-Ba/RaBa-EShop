using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Get
{
    public class GetSellerByIdQueryHandler : IBaseQueryHandler<GetSellerByIdQuery, SellerDto>
    {
        private readonly ShopContext _context;

        public GetSellerByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<SellerDto> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (seller is null) return null;

            return seller.MapSingle(_context);
        }
    }
}