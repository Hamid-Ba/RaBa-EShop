using Domain.CommentAgg;
using Domain.CommentAgg.Repository;
using Framework.Application;

namespace Application.CommentAgg.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.ProductId, request.Content, request.Status);
            await _commentRepository.AddEntityAsync(comment);
            await _commentRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}