using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.Banners.DTOs;

namespace Query.SiteEntities.Banners.Get
{
    public class GetBannerByIdQueryHandler : IBaseQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        public readonly ShopContext _context;

        public GetBannerByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(b => b.Id == request.Id);
            if (banner is null) return null;

            return banner.Map();
        }
    }
}