using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.AddToken
{
    public class AddTokenCommandHandler : IBaseCommandHandler<AddTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddTokenCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            var token = new UserToken(request.HashToken, request.HashRefreshToken, request.TokenExpireDate,
                request.RefreshTokenExpireDate, request.Device);

            user.AddToken(token);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
