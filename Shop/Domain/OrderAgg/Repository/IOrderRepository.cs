using Framework.Domain.Repository;

namespace Domain.OrderAgg.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetUserOpenOrderBy(long userId);
    }
}