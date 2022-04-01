using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserAddresses.GetAll
{
    public record GetAllUserAddressQuery(long UserId) : IBaseQuery<List<UserAddressDto>>;
}