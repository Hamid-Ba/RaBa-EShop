using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.ProductAgg.Edit
{
    public class EditProductCommand : IBaseCommand
    {
        public long Id { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondarySubCategoryId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImageName { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoDate { get; private set; }
        public SeoImage SeoImage { get; private set; }

        public Dictionary<string, string> Specifications { get; private set; }

        public EditProductCommand(long id, long categoryId, long subCategoryId, long secondarySubCategoryId, string title, string description,
         string imageName, IFormFile imageFile, string slug, SeoData seoDate, SeoImage seoImage, Dictionary<string, string> specifications)
        {
            Id = id;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Title = title;
            Description = description;
            ImageName = imageName;
            ImageFile = imageFile;
            Slug = slug;
            SeoDate = seoDate;
            SeoImage = seoImage;
            Specifications = specifications;
        }
    }
}