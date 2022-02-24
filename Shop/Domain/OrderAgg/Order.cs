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

        public void AddItem(OrderItem item)
        {
            Guard();

            var currentItem = Items.FirstOrDefault(i => i.Id == item.Id);

            if (currentItem is null) Items.Add(item);

            currentItem.ChangeCount(item.Count);
        }

        public void RemoveItem(long itemId)
        {
            Guard();

            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) Items.Remove(item);
        }

        public void ChangeCount(long itemId, int count)
        {
            Guard();

            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.ChangeCount(count);
        }

        public void IncreaseCount(long itemId, int count)
        {
            Guard();

            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.IncreaseCount(count);
        }

        public void DecreaseCount(long itemId, int count)
        {
            Guard();

            var item = Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null) item.DecreaseCount(count);
        }

        #endregion

        #region Status

        public void ChangeStatus(OrderStatus status) => Status = status;

        #endregion

        public void Checkout(OrderAddress address)
        {
            Guard();
            Address = address;
        }

        private void Guard() { if (Status != OrderStatus.Pending) throw new InvalidDomainDataException("این سفارش غیرقابل تغییر است"); }
    }
}