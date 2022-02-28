using Domain.RoleAgg;
using Domain.RoleAgg.Repository;
using Domain.RoleAgg.Services;
using Framework.Application;

namespace Application.RoleAgg.Create
{
    public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleDomainService _roleDomainService;

        public CreateRoleCommandHandler(IRoleRepository roleRepository, IRoleDomainService roleDomainService)
        {
            _roleRepository = roleRepository;
            _roleDomainService = roleDomainService;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            List<RolePermission> rolePermissions = new List<RolePermission>();

            request.Permissions.ForEach(p =>
            {
                rolePermissions.Add(new RolePermission(p));
            });

            var role = new Role(request.Title, request.Description, rolePermissions, _roleDomainService);

            await _roleRepository.AddEntityAsync(role);
            await _roleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}