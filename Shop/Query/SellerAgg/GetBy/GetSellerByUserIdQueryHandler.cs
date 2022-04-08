using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.GetBy
{
    public class GetSellerByUserIdQueryHandler : IBaseQueryHandler<GetSellerByUserIdQuery, SellerDto>
    {
        private readonly ShopContext _context;

        public GetSellerByUserIdQueryHandler(ShopContext shopContext) => _context = shopContext;

        public async Task<SellerDto> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (user is null) return new SellerDto();

            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.UserId == user.Id);
            return seller.Map(_context);
        }
    }
}