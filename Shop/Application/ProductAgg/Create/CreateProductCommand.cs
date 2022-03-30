using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.ProductAgg.Create
{
    public class CreateProductCommand : IBaseCommand
    {
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IFormFile ImageName { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoDate { get; private set; }
        public SeoImage SeoImage { get; private set; }

        public Dictionary<string,string> Specifications { get; private set; }

        public CreateProductCommand(long categoryId, long subCategoryId, long secondarySubCategoryId, string title, string description, IFormFile imageName,
            string slug, SeoData seoDate, SeoImage seoImage, Dictionary<string, string> specifications)
        {
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Title = title;
            Description = description;
            ImageName = imageName;
            Slug = slug;
            SeoDate = seoDate;
            SeoImage = seoImage;
            Specifications = specifications;
        }
    }
}
