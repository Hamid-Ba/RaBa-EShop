using Domain.ProductAgg;
using Domain.SellerAgg;
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
            var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
                return new ProductCategoryDto
                {
                    Id = categoryId,
                    Title = category.Title,
                    CreationDate = category.CreationDate
                };

            return null;
        }

        public static ProductDto MapSingle(this Product product, ShopContext context)
        {
            if (product is null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Slug = product.Slug,
                ImageName = product.ImageName,
                SeoImage = product.SeoImage,
                Description = product.Description,
                Images = MapImages(product.Images),
                Specifications = MapSpecifications(product.Specifications),
                SeoDate = product.SeoDate,
                CreationDate = product.CreationDate,
                MainCategory = MapCategory(product.CategoryId, context),
                SubCategory = MapCategory(product.SubCategoryId, context),
                SecondarySubCategory = MapCategory(product.SecondarySubCategoryId, context)
            };
        }

        private static List<ProductSpecificationDto> MapSpecifications(List<ProductSpecification> specifications)
        {
            if (specifications is null) return null;

            return specifications.Select(s => new ProductSpecificationDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                Key = s.Key,
                Value = s.Value
            }).ToList();
        }

        private static List<ProductImageDto> MapImages(List<ProductImage> images)
        {
            if (images is null) return null;

            return images.Select(i => new ProductImageDto
            {
                Id = i.Id,
                ProductId = i.ProductId,
                ImageName = i.ImageName,
                SeoImage = i.SeoImage,
                Sequence = i.Sequence
            }).ToList();
        }

        public static List<ProductShopDto> MapProductShop(this List<Product> products, List<Inventory> inventories)
        {
            if (products is null) return null;

            var firstFilterResult = products.Where(p => !p.IsDelete).Select(p => new ProductShopDto
            {
                Id = p.Id,
                Title = p.Title,
                Slug = p.Slug,
                ImageName = p.ImageName,
                CreationDate = p.CreationDate,
            }).ToList();

            firstFilterResult.ForEach(p => p.InventoryId = inventories.FirstOrDefault(i => i.ProductId == p.Id)?.Id);
            firstFilterResult.ForEach(p => p.Price = inventories.FirstOrDefault(i => i.ProductId == p.Id)?.Price);

            var result = firstFilterResult.Where(p => p.InventoryId != null).ToList();

            return result;
        }
    }
}