using Framework.Query;
using Query.CommentAgg.DTOs;

namespace Query.CommentAgg.GetById
{
    public record GetCommentByIdQuery(long Id) : IBaseQuery<CommentDto>;
}