using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.Active
{
    public class ActiveUserCommandHandler : IBaseCommandHandler<ActiveUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public ActiveUserCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.Active();
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}