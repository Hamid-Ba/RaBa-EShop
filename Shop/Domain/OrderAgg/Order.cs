using Domain.OrderAgg.Enums;
using Domain.OrderAgg.ValueObjects;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        public long UserId { get; private set; }
        public double TotalPrice
        {
            get => Items.Sum(i => i.TotalPrice * i.Count);
        }
        public double PayAmount
        {
            get => DiscountPrice is null ? TotalPrice : TotalPrice - (double)DiscountPrice;
        }
        public double? DiscountPrice
        {
            get => Items?.Sum(i => i.Discount?.Amount * i.Count);
        }
        public PaymentMethod Method { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime? PayedDate { get; private set; }

        public OrderAddress Address { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        #region Items

        public void AddItem(OrderItem item) => Items.Add(item);

        public void RemoveItem(long itemId)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) Items.Remove(item);
        }

        public void ChangeCount(long itemId, int count)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.ChangeCount(count);
        }

        public void IncreaseCount(long itemId, int count)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.IncreaseCount(count);
        }

        public void DecreaseCount(long itemId, int count)
        {
            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.DecreaseCount(count);
        }

        #endregion

        #region Status

        public void ChangeStatus(OrderStatus status)
        {
            ChangeGuard();
            Status = status;
        }

        #endregion

        private void ChangeGuard() { if (Status == OrderStatus.Pending) throw new InvalidDomainDataException("وضعیت سفارش باز هست"); }
    }
}