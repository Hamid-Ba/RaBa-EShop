using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.GetByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string phoneNumber) : IBaseQuery<UserDto>;
}