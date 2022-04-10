using Domain.OrderAgg.Enums;
using Domain.OrderAgg.ValueObjects;
using Framework.Query;
using Framework.Query.Filter;

namespace Query.OrderAgg.DTOs
{
    public class OrderDto : BaseDto
    {
        public long UserId { get; set; }
        public string FullName { get; set; }
        public double TotalPrice { get; set; }
        public double PayAmount { get; set; }
        public double? DiscountPrice { get; set; }
        public PaymentMethod Method { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? PayedDate { get; set; }

        public OrderAddressDto Address { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto : BaseDto
    {
        public long OrderId { get; set; }
        public long InventoryId { get; set; }
        public string ShopName { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public double PayAmount { get; set; }
        public OrderDiscount? Discount { get; set; }
    }

    public class OrderAddressDto : BaseDto
    {
        public long OrderId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
    }

    public class OrderFilterParam : BaseFilterParam
    {
        public long? UserId { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class OrderFilterResult : BaseFilter<OrderDto, OrderFilterParam>
    {
    }
}