using Domain.RoleAgg.Services;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public List<RolePermission> Permissions { get; private set; }

        public Role(string title, string description,List<RolePermission> permissions,IRoleDomainService roleService)
        {
            Guard(title, roleService);
            Title = title;
            Description = description;
            Permissions = permissions;
        }

        public void Edit(string title, string description, IRoleDomainService roleService)
        {
            Guard(title, roleService);
            Title = title;
            Description = description;
        }

        public void AddPermission(List<RolePermission> permissions)
        {
            permissions.ForEach(p => p.RoleId = Id);
            Permissions.AddRange(permissions);
        }

        public void EditPermission(List<RolePermission> permissions)
        {
            Permissions.Clear();
            permissions.ForEach(p => p.RoleId = Id);
            Permissions.AddRange(permissions);
        }

        public async void Guard(string title,IRoleDomainService roleService)
        {
            NullOrEmptyDomainDataException.CheckString(title,nameof(title));

            if(Title != title)
                if(await roleService.IsThisTitleExist(title)) throw new InvalidDomainDataException("این عنوان قبلا ثبت شده است");
        }
    }
}