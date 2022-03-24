using Framework.Domain.ValueObjects;
using Framework.Query;

namespace Query.SiteEntities.Sliders.DTOs
{
    public class SliderDto : BaseDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageName { get; set; }
        public SeoImage SeoImage { get; set; }
        public bool IsActive { get; set; }
    }
}