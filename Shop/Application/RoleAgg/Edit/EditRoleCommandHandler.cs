using Domain.RoleAgg;
using Domain.RoleAgg.Repository;
using Domain.RoleAgg.Services;
using Framework.Application;

namespace Application.RoleAgg.Edit
{
    internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleDomainService _roleDomainService;

        public EditRoleCommandHandler(IRoleRepository roleRepository, IRoleDomainService roleDomainService)
        {
            _roleRepository = roleRepository;
            _roleDomainService = roleDomainService;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetEntityAsyncBy(request.Id);
            if (role is null) return OperationResult.NotFound();

            role.Edit(request.Title, request.Description, _roleDomainService);

            List<RolePermission> rolePermissions = new List<RolePermission>();
            request.Permissions.ForEach(p =>
            {
                rolePermissions.Add(new RolePermission(p));
            });
            role.EditPermission(rolePermissions);

            await _roleRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}