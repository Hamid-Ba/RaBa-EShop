using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CommentAgg.DTOs;

namespace Query.CommentAgg.GetAll
{
    public class GetAllCommentsQueryHandler : IBaseQueryHandler<GetAllCommentsQuery, CommentFilterResult>
    {
        private readonly ShopContext _context;

        public GetAllCommentsQueryHandler(ShopContext context) => _context = context;

        public async Task<CommentFilterResult> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var comments = _context.Comments.OrderByDescending(o => o.Id).AsQueryable();

            #region Filters

            if (@params.UserId != 0)
                comments = comments.Where(c => c.UserId == @params.UserId);

            if (@params.StartDate != null)
                comments = comments.Where(c => c.CreationDate >= @params.StartDate);

            if (@params.EndDate != null)
                comments = comments.Where(c => c.CreationDate <= @params.EndDate);

            if (@params.Status != null)
                comments = comments.Where(c => c.Status == @params.Status);

            #endregion

            var commentsList = await comments.Skip((@params.PageId - 1) * @params.Take).Take(@params.Take).ToListAsync();

            var result = new CommentFilterResult
            {
                FilterParams = @params,
                Data = commentsList.Map()
            };

            result.GeneratePaging(comments, @params.Take, @params.PageId);

            return result;
        }
    }
}