using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.UserAgg.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetEntityAsyncBy(request.Id);
            if (user is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.Avatar, DirectoryImages.Avatars, request.AvatarName);

            List<UserRole> Roles = new List<UserRole>();

            request.Roles.ForEach(r =>
            {
                var role = new UserRole(r);
                Roles.Add(role);
            });

            user.Edit(request.FirstName, request.LastName, request.Email, request.PhoneNumber, imageName,
                request.Gender, _userDomainService);
            user.SetRoles(Roles);

            await _userRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}