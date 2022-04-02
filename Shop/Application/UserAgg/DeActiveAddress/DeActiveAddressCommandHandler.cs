using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.DeActiveAddress
{
    public class DeActiveAddressCommandHandler : IBaseCommandHandler<DeActiveAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeActiveAddressCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(DeActiveAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsTrackingAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            user.DeActiveAddress(request.AddressId);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}