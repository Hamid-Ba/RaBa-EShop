using Domain.SiteEntities;
using Query.SiteEntities.Banners.DTOs;

namespace Query.SiteEntities.Banners
{
    public static class BannerMapper
	{
		public static BannerDto Map(this Banner banner)
        {
			if (banner is null) return null;

			return new BannerDto
			{
				Id = banner.Id,
				ImageName = banner.ImageName,
				Link = banner.Link,
				SeoImage = banner.SeoImage,
				Position = banner.Position,
				CreationDate = banner.CreationDate
			};
        }
	}
}