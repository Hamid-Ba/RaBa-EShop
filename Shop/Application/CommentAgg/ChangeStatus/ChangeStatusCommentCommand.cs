using Domain.CommentAgg.Enums;
using Framework.Application;

namespace Application.CommentAgg.ChangeStatus
{
    public record ChangeStatusCommentCommand(long Id, CommentStatus Status) : IBaseCommand;
}