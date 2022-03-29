using Application.CommentAgg.ChangeStatus;
using Application.CommentAgg.Create;
using Framework.Presentation.Api;
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
        public async Task<ApiResult<CommentFilterResult>> GetAll([FromQuery] CommentFilterParam param) => QueryResult(await _commentFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<CommentDto>> Get(long id) => QueryResult(await _commentFacade.GetBy(id));

        [HttpPost]
        public async Task<ApiResult> Create(CreateCommentCommand command) => CommandResult(await _commentFacade.Create(command));

        [HttpPut]
        public async Task<ApiResult> ChangeStatus(ChangeStatusCommentCommand command) => CommandResult(await _commentFacade.ChangeStatus(command));
    }
}