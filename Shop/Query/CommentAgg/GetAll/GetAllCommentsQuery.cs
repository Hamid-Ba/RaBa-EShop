using Framework.Query;
using Query.CommentAgg.DTOs;

namespace Query.CommentAgg.GetAll
{
    public class GetAllCommentsQuery : QueryFilter<CommentFilterResult, CommentFilterParam>
    {
        public GetAllCommentsQuery(CommentFilterParam filter) : base(filter) { }
    }
}