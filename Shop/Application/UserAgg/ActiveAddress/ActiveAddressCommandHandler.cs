using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.ActiveAddress
{
    public class ActiveAddressCommandHandler : IBaseCommandHandler<ActiveAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public ActiveAddressCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(ActiveAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.ActiveAddress(request.AddressId);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}