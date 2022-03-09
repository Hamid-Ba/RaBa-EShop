using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Framework.Application;

namespace Application.UserAgg.ChargeWallet
{
    public class ChargeWalletCommandHandler : IBaseCommandHandler<ChargeWalletCommand>
    {
        private readonly IUserRepository _userRepository;

        public ChargeWalletCommandHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<OperationResult> Handle(ChargeWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetEntityAsyncBy(request.UserId);
            if (user is null) return OperationResult.NotFound();

            var wallet = new UserWallet(request.Amount);
            user.ChargeWallet(wallet);

            await _userRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}

