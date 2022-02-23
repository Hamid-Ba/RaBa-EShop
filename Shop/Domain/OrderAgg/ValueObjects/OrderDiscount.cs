using Framework.Domain;

namespace Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public int Rate { get; private set; }
        public double Amount { get; private set; }

        public OrderDiscount(int rate, double amount)
        {
            Rate = rate;
            Amount = amount;
        }

    }
}