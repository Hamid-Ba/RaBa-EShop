using Framework.Query;
using Query.SiteEntities.Sliders.DTOs;

namespace Query.SiteEntities.Sliders.Get
{
    public record GetSliderByIdQuery(long Id) : IBaseQuery<SliderDto>;
}