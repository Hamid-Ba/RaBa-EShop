using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.UpdateToken
{
    public class UpdateTokenCommandHandler : IBaseCommandHandler<UpdateTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateTokenCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.UpdateToken(request.TokenId, request.NewHashToken, request.NewHashRefreshToken, request.NewTokenExpireDate,
                request.NewRefreshTokenExpireDate);

            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}