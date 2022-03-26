using Application.CommentAgg.ChangeStatus;
using Application.CommentAgg.Create;
using Framework.Application;
using MediatR;
using Query.CommentAgg.DTOs;
using Query.CommentAgg.GetAll;
using Query.CommentAgg.GetById;

namespace Presentation.Facade.CommentAgg
{
    public class CommentFacade : ICommentFacade
	{
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> ChangeStatus(ChangeStatusCommentCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateCommentCommand command) => await _mediator.Send(command);

        public async Task<CommentFilterResult> GetAll(CommentFilterParam filter) => await _mediator.Send(new GetAllCommentsQuery(filter));

        public async Task<CommentDto> GetBy(long id) => await _mediator.Send(new GetCommentByIdQuery(id));
    }
}