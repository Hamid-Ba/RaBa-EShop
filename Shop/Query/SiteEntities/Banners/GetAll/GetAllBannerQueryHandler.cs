using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.SiteEntities.Banners.DTOs;

namespace Query.SiteEntities.Banners.GetAll
{
    public class GetAllBannerQueryHandler : IBaseQueryHandler<GetAllBannerQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetAllBannerQueryHandler(ShopContext context) => _context = context;

        public async Task<List<BannerDto>> Handle(GetAllBannerQuery request, CancellationToken cancellationToken)
        {
            var banners = await _context.Banners.ToListAsync();

            return banners.Select(b => b.Map()).ToList();
        }
    }
}