using Domain.SellerAgg.Enums;
using Framework.Query;
using Framework.Query.Filter;

namespace Query.SellerAgg.DTOs
{
    public class SellerDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
        public SellerStatus Status { get; set; }
        public string StatusDescriber { get; set; }

        public List<InventoryDto?> Inventories { get; set; }
    }

    public class InventoryDto : BaseDto
    {
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public string SellerShopName { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }

    public class SellerFilterParam : BaseFilterParam
    {
        public string? ShopName { get; set; }
        public string? NationalCode { get; set; }
    }

    public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParam>
    {
        public SellerFilterResult(List<SellerDto> data, SellerFilterParam filterParams) : base(data, filterParams)
        {
        }
    }
}