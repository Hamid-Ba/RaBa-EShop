using Domain.ProductAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;
using Framework.Domain.Utils;
using Framework.Domain.ValueObjects;

namespace Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoDate { get; private set; }
        public SeoImage SeoImage { get; private set; }

        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        public Product(long categoryId, long subCategoryId, long secondarySubCategoryId, string title, string description,
            string imageName, string slug, SeoData seoDate, SeoImage seoImage, IProductDomainService productService)
        {
            Guard(title, description, slug.ToSlug(), productService);

            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Title = title;
            Description = description;
            ImageName = imageName;
            Slug = slug.ToSlug();
            SeoDate = seoDate;
            SeoImage = seoImage;

            Images = new List<ProductImage>();
            Specifications = new List<ProductSpecification>();
        }

        public void Edit(long categoryId, long subCategoryId, long secondarySubCategoryId, string title, string description,
            string imageName, string slug, SeoData seoDate, SeoImage seoImage, IProductDomainService productService)
        {
            Guard(title, description, slug.ToSlug(), productService);

            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Title = title;
            Description = description;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            Slug = slug.ToSlug();
            SeoDate = seoDate;
            SeoImage = seoImage;
        }

        #region Images

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public void EditImage(long imageId,ProductImage image)
        {
            DeleteImage(imageId);
            AddImage(image);
        }

        public void DeleteImage(long imageId)
        {
            var oldImage = Images.FirstOrDefault(i => i.Id == imageId);

            if (oldImage != null) Images.Remove(oldImage);

            else throw new InvalidDomainDataException("همچین تصویری وجود ندارد");
        }

        #endregion

        #region Specifications

        public void AddSepcification(List<ProductSpecification> specifications)
        {
            Specifications.Clear();
            specifications.ForEach(s => s.ProductId = Id);
            Specifications.AddRange(specifications);
        }

        //public void Delete(long specId)
        //{
        //    var oldSpec = Specifications.FirstOrDefault(s => s.Id == specId);

        //    if (oldSpec != null) Specifications.Remove(oldSpec);
        //    else throw new InvalidDomainDataException("همیچن ویژگی وجود ندارد");
        //}

        #endregion

        public async void Guard(string title, string description, string slug, IProductDomainService productService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (Slug != slug)
                if (await productService.IsSlugExist(slug)) throw new InvalidDomainDataException("این اسلاگ استفاده شده است");
        }

    }
}