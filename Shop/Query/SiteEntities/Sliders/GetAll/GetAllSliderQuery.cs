using Framework.Query;
using Query.SiteEntities.Sliders.DTOs;

namespace Query.SiteEntities.Sliders.GetAll
{
    public record GetAllSliderQuery : IBaseQuery<List<SliderDto>>;
}