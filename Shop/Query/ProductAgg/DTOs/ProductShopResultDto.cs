using Framework.Query;
using Framework.Query.Filter;
using Query.CategoryAgg.DTOs;

namespace Query.ProductAgg.DTOs
{
    public class ProductShopFilterResult :  BaseFilter<ProductShopDto, ProductShopFilterParam>
	{
        public CategoryDto? Category { get; set; }

        public ProductShopFilterResult(List<ProductShopDto> data, ProductShopFilterParam filterParams) : base(data, filterParams)
        {
        }
    }

    public class ProductShopDto : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public long InventoryId { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
    }
    public class ProductShopFilterParam : BaseFilterParam
    {
        public string? CategorySlug { get; set; } = "";
        public string? Search { get; set; } = "";
        public bool OnlyAvailableProducts { get; set; } = false;
        public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
    }

    public enum ProductSearchOrderBy
    {
        Latest,
        Expensive,
        Cheapest,
    }
}