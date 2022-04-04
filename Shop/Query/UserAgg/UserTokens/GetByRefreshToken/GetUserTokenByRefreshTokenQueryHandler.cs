using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserTokens.GetByRefreshToken
{
    public class GetUserTokenByRefreshTokenQueryHandler : IBaseQueryHandler<GetUserTokenByRefreshTokenQuery,UserTokenDto>
    {
        private readonly ShopContext _context;

        public GetUserTokenByRefreshTokenQueryHandler(ShopContext context) => _context = context;

        public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Tokens.Any(t => t.HashRefreshToken == request.HashRefreshToken));
            if (user is null) return new UserTokenDto();

            var token = user.Tokens.FirstOrDefault(t => t.HashRefreshToken == request.HashRefreshToken);
            if (token is null) return new UserTokenDto();

            return token.MapToken();
        }
    }
}