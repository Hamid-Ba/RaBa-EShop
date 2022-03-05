using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Application.Utils;

namespace Application.UserAgg.Create
{
    internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserDomainService _userDomainService;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var imageName = Uploader.ImageUploader(request.Avatar, DirectoryImages.Avatars, null!);

            var password = _passwordHasher.Hash(request.Password);

            var user = new User(request.FirstName, request.LastName, request.Email, request.PhoneNumber, password,
                imageName, request.Gender, _userDomainService);
            await _userRepository.AddEntityAsync(user);

            List<UserRole> Roles = new List<UserRole>();

            request.Roles.ForEach(r =>
            {
                var role = new UserRole(r);
                Roles.Add(role);
            });
            user.SetRoles(Roles);

            await _userRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}