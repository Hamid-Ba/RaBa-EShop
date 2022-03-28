using Domain.RoleAgg.Repository;
using Domain.RoleAgg.Services;

namespace Application.RoleAgg
{
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleDomainService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public bool IsThisTitleExist(string title) => _roleRepository.Exists(r => r.Title == title);
        
    }
}