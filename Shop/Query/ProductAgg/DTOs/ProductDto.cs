using Framework.Domain.ValueObjects;
using Framework.Query;
using Framework.Query.Filter;

namespace Query.ProductAgg.DTOs
{
    public class ProductDto : BaseDto
	{
        public ProductCategoryDto MainCategory { get; set; }
        public ProductCategoryDto SubCategory { get; set; }
        public ProductCategoryDto SecondarySubCategory{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string Slug { get;  set; }
        public SeoData SeoDate { get; set; }
        public SeoImage SeoImage { get; set; }

        public List<ProductImageDto> Images { get; set; }
        public List<ProductSpecificationDto> Specifications { get; set; }
    }

    public class ProductsDto : BaseDto
    {
        public ProductCategoryDto MainCategory { get; set; }
        public ProductCategoryDto SubCategory { get; set; }
        public ProductCategoryDto SecondarySubCategory { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
        public SeoImage SeoImage { get; set; }
    }

    public class ProductImageDto : BaseDto
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public SeoImage SeoImage { get; set; }
        public int Sequence { get;  set; }
    }

    public class ProductSpecificationDto : BaseDto
    {
        public long ProductId { get;  set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ProductCategoryDto : BaseDto
    {
        public string Title { get; set; }
    }

    public class ProductFilterParam : BaseFilterParam
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
    }

    public class ProductFilterResult : BaseFilter<ProductsDto, ProductFilterParam>
    {
        public ProductFilterResult(List<ProductsDto> data, ProductFilterParam filterParams) : base(data, filterParams)
        {
        }
    }
}