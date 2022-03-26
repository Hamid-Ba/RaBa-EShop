using Application.RoleAgg.Create;
using Application.RoleAgg.Edit;
using Framework.Application;
using Query.RoleAgg.DTOs;

namespace Presentation.Facade.RoleAgg
{
    public interface IRoleFacade
	{
        #region Command
        Task<OperationResult> Edit(EditRoleCommand command);
        Task<OperationResult> Create(CreateRoleCommand command);
        #endregion

        #region Query
        Task<RoleDto> GetBy(long id);
        Task<List<RoleDto>> GetAll();
        #endregion

    }
}