using Application.CommentAgg.ChangeStatus;
using Application.CommentAgg.Create;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.CommentAgg;
using Query.CommentAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class CommentController : BaseApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade) => _commentFacade = commentFacade;

        [HttpGet]
        [PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult<CommentFilterResult>> GetAll([FromQuery] CommentFilterParam param) => QueryResult(await _commentFacade.GetAll(param));

        [HttpGet("{id}")]
        [PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult<CommentDto>> Get(long id) => QueryResult(await _commentFacade.GetBy(id));

        [HttpPost]
        [Authorize]
        public async Task<ApiResult> Create(CreateCommentCommand command) => CommandResult(await _commentFacade.Create(command));

        [HttpPut]
        [PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult> ChangeStatus(ChangeStatusCommentCommand command) => CommandResult(await _commentFacade.ChangeStatus(command));
    }
}