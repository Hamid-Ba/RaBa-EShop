using Application.RoleAgg.Create;
using Application.RoleAgg.Edit;
using Framework.Application;
using MediatR;
using Query.RoleAgg.DTOs;
using Query.RoleAgg.Get;
using Query.RoleAgg.GetAll;

namespace Presentation.Facade.RoleAgg
{
    public class RoleFacade : IRoleFacade
	{
        private readonly IMediator _mediator;

        public RoleFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Create(CreateRoleCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditRoleCommand command) => await _mediator.Send(command);

        public async Task<List<RoleDto>> GetAll() => await _mediator.Send(new GetAllRolesQuery());

        public async Task<RoleDto> GetBy(long id) => await _mediator.Send(new GetRoleByIdQuery(id));
    }
}