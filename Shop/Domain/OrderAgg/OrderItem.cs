using Common.Domain;
using Common.Domain.Exceptions;
using Domain.OrderAgg.ValueObjects;

namespace Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public long OrderId { get; internal set; }
        public int Count { get; private set; }
        public double TotalPrice { get; private set; }
        public double PayAmount { get; private set; }
        public OrderDiscount? Discount { get; private set; }

        public void ChangeCount(int count)
        {
            CountGuard(count);
            Count = count;
        }

        public void IncreaseCount(int count)
        {
            CountGuard(count);
            Count += count;
        }

        public void DecreaseCount(int count)
        {
            CountGuard(count);
            DecreaseGuard(count);
            Count -= count;
        }

        public void Finally(double totalPrice, double payAmount, OrderDiscount? discount)
        {
            TotalPrice = totalPrice;
            PayAmount = payAmount;
            Discount = discount;
        }

        private void CountGuard(int count) { if (count < 0) throw new InvalidDomainDataException("تعداد نامعتبر است"); }
        private void DecreaseGuard(int count) { if (Count - count < 0) throw new InvalidDomainDataException("تعداد نامعتبر است"); }

    }
}