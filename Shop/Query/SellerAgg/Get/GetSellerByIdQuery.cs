using Framework.Query;
using Query.SellerAgg.DTOs;

namespace Query.SellerAgg.Get
{
    public record GetSellerByIdQuery(long Id) : IBaseQuery<SellerDto>;
}