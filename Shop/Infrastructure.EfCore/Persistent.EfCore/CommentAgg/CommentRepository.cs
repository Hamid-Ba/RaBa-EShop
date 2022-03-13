using Domain.CommentAgg;
using Domain.CommentAgg.Repository;
using Framework.Infrastructure;

namespace Infrastructure.Persistent.EfCore.CommentAgg
{
    public class CommentRepository : Repository<Comment> , ICommentRepository
	{
		private readonly ShopContext _context;

		public CommentRepository(ShopContext context) : base(context) => _context = context;
	}
}