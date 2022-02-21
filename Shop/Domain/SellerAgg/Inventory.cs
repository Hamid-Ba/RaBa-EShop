using Common.Domain;
using Common.Domain.Exceptions;

namespace Domain.SellerAgg
{
    public class Inventory : BaseEntity
    {
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public double Price { get; private set; }

        public Inventory(long productId, int count, double price)
        {
            Guard(count, price);

            ProductId = productId;
            Count = count;
            Price = price;
        }

        public void Edit(long productId, int count, double price)
        {
            Guard(count, price);

            ProductId = productId;
            Count = count;
            Price = price;
        }

        public void ChangeCount(int count)
        {
            Guard(count, 1);

            Count = count;
        }

        public void ChangePrice(double price)
        {
            Guard(1, price);

            Price = price;
        }

        public void Guard(int count, double price)
        {
            if (count < 0) throw new InvalidDomainDataException("تعداد نامعتبر هست");
            if (price <= 0) throw new InvalidDomainDataException("قیمت نامعتبر هست");
        }
    }
}