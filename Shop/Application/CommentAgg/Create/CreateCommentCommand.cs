using Domain.CommentAgg.Enums;
using Framework.Application;

namespace Application.CommentAgg.Create
{
    public record CreateCommentCommand(long UserId, long ProductId, string Content, CommentStatus Status) : IBaseCommand;
}