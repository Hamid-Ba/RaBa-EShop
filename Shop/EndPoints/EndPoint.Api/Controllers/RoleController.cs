using Application.RoleAgg.Create;
using Application.RoleAgg.Edit;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.RoleAgg;
using Query.RoleAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    [PermissionChecker(Permission.Role_Management)]
    public class RoleController : BaseApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade) => _roleFacade = roleFacade;

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetAll() => QueryResult(await _roleFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<RoleDto>> GetBy(long id) => QueryResult(await _roleFacade.GetBy(id));

        [HttpPost]
        public async Task<ApiResult> Create(CreateRoleCommand command) => CommandResult(await _roleFacade.Create(command));

        [HttpPut]
        public async Task<ApiResult> Edit(EditRoleCommand command) => CommandResult(await _roleFacade.Edit(command));
    }
}