using Framework.Domain.Enums;
using Framework.Domain.ValueObjects;
using Framework.Query;

namespace Query.SiteEntities.Banners.DTOs
{
    public class BannerDto : BaseDto
	{
		public string Link { get;  set; }
		public string ImageName { get; set; }
		public SeoImage SeoImage { get; set; }
		public BannerPosition Position { get; set; }
	}
}

