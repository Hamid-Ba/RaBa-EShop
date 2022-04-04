using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserTokens.GetByRefreshToken
{
    public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IBaseQuery<UserTokenDto>;
}