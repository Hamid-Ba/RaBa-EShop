using Domain.SiteEntities;
using Query.SiteEntities.Sliders.DTOs;

namespace Query.SiteEntities.Sliders
{
    public static class SliderMapper
	{
		public static SliderDto Map(this Slider slider)
        {
			if (slider is null) return null;

			return new SliderDto
			{
				Id = slider.Id,
				Title = slider.Title,
				ImageName = slider.ImageName,
				Link = slider.Link,
				SeoImage = slider.SeoImage,
				IsActive = slider.IsActive,
				CreationDate = slider.CreationDate
			};
        }
	}
}