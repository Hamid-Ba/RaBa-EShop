using Domain.ProductAgg;
using Infrastructure.Persistent.EfCore;
using Query.ProductAgg.DTOs;

namespace Query.ProductAgg
{
    public static class ProductMapper
    {
        public static ProductsDto Map(this Product product, ShopContext context)
        {
            if (product is null) return null;

            return new ProductsDto
            {
                Id = product.Id,
                Title = product.Title,
                Slug = product.Slug,
                ImageName = product.ImageName,
                SeoImage = product.SeoImage,
                CreationDate = product.CreationDate,
                MainCategory = MapCategory(product.CategoryId, context),
                SubCategory = MapCategory(product.SubCategoryId, context),
                SecondarySubCategory = MapCategory(product.SecondarySubCategoryId, context)
            };
        }

        public static ProductCategoryDto MapCategory(long categoryId, ShopContext context)
        {
            var category =  context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
                return new ProductCategoryDto
                {
                    Id = categoryId,
                    Title = category.Title,
                    CreationDate = category.CreationDate
                };

            return null;
        }
    }
}