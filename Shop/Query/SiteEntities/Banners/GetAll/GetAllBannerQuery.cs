using Framework.Query;
using Query.SiteEntities.Banners.DTOs;

namespace Query.SiteEntities.Banners.GetAll
{
    public record GetAllBannerQuery : IBaseQuery<List<BannerDto>>;
}