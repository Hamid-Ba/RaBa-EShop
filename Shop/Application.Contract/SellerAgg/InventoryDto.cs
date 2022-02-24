namespace Application.Contract.SellerAgg
{
    public class InventoryDto
    {
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
