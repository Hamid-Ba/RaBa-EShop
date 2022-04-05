using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.RemoveToken
{
    public class RemoveTokenCommandHandler : IBaseCommandHandler<RemoveTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveTokenCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(RemoveTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.RemoveToken(request.TokenId);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}