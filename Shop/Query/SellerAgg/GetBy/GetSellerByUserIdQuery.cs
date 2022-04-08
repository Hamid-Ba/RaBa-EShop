using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.GetBy
{
    public record GetSellerByUserIdQuery(long UserId) : IBaseQuery<SellerDto>;
}