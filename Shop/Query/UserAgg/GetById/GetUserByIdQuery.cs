using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetById
{
    public record GetUserByIdQuery(long Id) : IBaseQuery<UserDto>;
}