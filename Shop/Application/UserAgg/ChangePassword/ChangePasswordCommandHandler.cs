using Domain.UserAgg.Repository;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;

namespace Application.UserAgg.ChangePassword
{
    internal class ChangePasswordCommandHandler : IBaseCommandHandler<ChangePasswordCommand>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetEntityAsyncBy(request.Id);
            if (user is null) return OperationResult.NotFound();

            string newPassword = "";

            if (!string.IsNullOrWhiteSpace(request.NewPassword))
                newPassword = _passwordHasher.Hash(request.NewPassword);

            user.ChangePassword(newPassword);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}