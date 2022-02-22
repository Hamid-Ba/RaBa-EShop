using Common.Domain;
using Common.Domain.Exceptions;
using Framework.Domain.ValueObjects;

namespace Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public SeoImage SeoImage { get; private set; }
        public int Sequence { get; private set; }

        public ProductImage(string imageName, SeoImage seoImage, int sequence)
        {
            Guard(imageName);

            ImageName = imageName;
            SeoImage = seoImage;
            Sequence = sequence;
        }

        public void Edit(string imageName, SeoImage seoImage, int sequence)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            SeoImage = seoImage;
            Sequence = sequence;
        }

        public void Guard(string imageName) => NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}