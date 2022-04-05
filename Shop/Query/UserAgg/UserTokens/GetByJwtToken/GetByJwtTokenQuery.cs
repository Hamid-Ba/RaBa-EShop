using System;
using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserTokens.GetByJwtToken
{
    public record GetUserTokenByJwtTokenQuery(string HashToken) : IBaseQuery<UserTokenDto>;
}