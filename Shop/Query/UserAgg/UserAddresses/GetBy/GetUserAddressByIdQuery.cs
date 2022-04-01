using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserAddresses.GetBy
{
    public record GetUserAddressByIdQuery(long Id,long UserId) : IBaseQuery<UserAddressDto>;
}