using Framework.Query;
using Infrastructure.Persistent.EfCore;
using Microsoft.EntityFrameworkCore;
using Query.CommentAgg.DTOs;

namespace Query.CommentAgg.GetById
{
    public class GetCommentByIdQueryHandler : IBaseQueryHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ShopContext _context;

        public GetCommentByIdQueryHandler(ShopContext context) => _context = context;

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.Id);

            return comment.Map();
        }
    }
}