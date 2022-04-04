using Domain.UserAgg.Repository;
using Framework.Query;
using Query.UserAgg.DTOs;

namespace Query.UserAgg.UserTokens.GetByRefreshToken
{
    public class GetUserTokenByRefreshTokenQueryHandler : IBaseQueryHandler<GetUserTokenByRefreshTokenQuery,UserTokenDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserTokenByRefreshTokenQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return new UserTokenDto();

            var token = user.Tokens.FirstOrDefault(t => t.HashRefreshToken == request.HashRefreshToken);
            if (token is null) return new UserTokenDto();

            return token.MapToken();
        }
    }
}