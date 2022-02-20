using Common.Domain;

namespace Domain.OrderAgg.ValueObjects
{
    public class PaymentMethod : ValueObject
    {
        public string Title { get; private set; }
        public double Cost { get; private set; }

        public PaymentMethod(string title, double cost)
        {
            Title = title;
            Cost = cost;
        }
    }
}
