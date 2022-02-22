using Common.Domain;
using Framework.Domain.ValueObjects;

namespace Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public SeoImage SeoImage { get; private set; }

        public Slider(string title, string link, string imageName, SeoImage seoImage)
        {
            Title = title;
            Link = link;
            ImageName = imageName;
            SeoImage = seoImage;
        }

        public void Edit(string title, string link, string imageName, SeoImage seoImage)
        {
            Title = title;
            Link = link;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            SeoImage = seoImage;
        }
    }
}