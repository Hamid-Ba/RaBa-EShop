using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;

namespace Application.UserAgg.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserDomainService _userDomainService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var password = _passwordHasher.Hash(request.Password);

            var user = User.Register(request.PhoneNumber, password, _userDomainService);

            await _userRepository.AddEntityAsync(user);
            await _userRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}