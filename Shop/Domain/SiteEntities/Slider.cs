using Framework.Domain;
using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public string Title { get; private set; }
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public SeoImage SeoImage { get; private set; }
        public bool IsActive { get; private set; }

        private Slider() { }

        public Slider(string title, string link, string imageName, SeoImage seoImage)
        {
            Guard(title, link);

            Title = title;
            Link = link;
            ImageName = imageName;
            SeoImage = seoImage;
            IsActive = false;
        }

        public void Edit(string title, string link, string imageName, SeoImage seoImage)
        {
            Guard(title, link);

            Title = title;
            Link = link;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            SeoImage = seoImage;
        }

        public void ChangeActivation(bool isActive) => IsActive = isActive;

        public void Guard(string title, string link)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        }
    }
}