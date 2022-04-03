using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.DeActive
{
    public class DeActiveUserCommandHandler : IBaseCommandHandler<DeActiveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeActiveUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(DeActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.DeActive();
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}