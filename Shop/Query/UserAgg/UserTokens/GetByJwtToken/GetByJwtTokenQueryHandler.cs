using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserTokens.GetByJwtToken
{
    public class GetUserTokenByJwtTokenQueryHandler : IBaseQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
    {
        private readonly ShopContext _shopContext;

        public GetUserTokenByJwtTokenQueryHandler(ShopContext shopContext) => _shopContext = shopContext;

        public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _shopContext.Users.FirstOrDefaultAsync(u => u.Tokens.Any(t => t.HashToken == request.HashToken));
            if (user is null) return null;

            var token = user.Tokens.FirstOrDefault(t => t.HashToken == request.HashToken);
            if (token is null) return null;

            return token.MapToken();
        }
    }
}