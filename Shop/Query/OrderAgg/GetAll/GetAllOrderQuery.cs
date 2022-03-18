using Framework.Query;
using Query.OrderAgg.DTOs;

namespace Query.OrderAgg.GetAll
{
    public class GetAllOrderQuery : QueryFilter<OrderFilterResult, OrderFilterParam>
    {
        public GetAllOrderQuery(OrderFilterParam filterParams) : base(filterParams)
        {
        }
    }
}