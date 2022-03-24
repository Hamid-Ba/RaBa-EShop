using Framework.Query;
using Query.SiteEntities.Banners.DTOs;

namespace Query.SiteEntities.Banners.Get
{
    public record GetBannerByIdQuery(long Id) : IBaseQuery<BannerDto>;
}