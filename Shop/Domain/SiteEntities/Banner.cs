using Framework.Domain;
using Framework.Domain.Enums;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Domain.SiteEntities
{
    public class Banner : BaseEntity
    {
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public SeoImage SeoImage { get; private set; }
        public BannerPosition Position { get; private set; }

        private Banner() { }

        public Banner(string link, string imageName, SeoImage seoImage, BannerPosition position)
        {
            Guard(link);

            Link = link;
            ImageName = imageName;
            SeoImage = seoImage;
            Position = position;
        }

        public void Edit(string link, string imageName, SeoImage seoImage, BannerPosition position)
        {
            Guard(link);

            Link = link;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            SeoImage = seoImage;
            Position = position;
        }

        public void Guard(string link) => NullOrEmptyDomainDataException.CheckString(link, nameof(link));
    }
}