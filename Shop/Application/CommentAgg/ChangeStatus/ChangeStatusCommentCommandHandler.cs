using Domain.CommentAgg.Repository;
using Framework.Application;

namespace Application.CommentAgg.ChangeStatus
{
    public class ChangeStatusCommentCommandHandler : IBaseCommandHandler<ChangeStatusCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public ChangeStatusCommentCommandHandler(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public async Task<OperationResult> Handle(ChangeStatusCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsTrackingAsyncBy(request.Id);
            if (comment is null) return OperationResult.NotFound();

            comment.ChangeStatus(request.Status);
            await _commentRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}