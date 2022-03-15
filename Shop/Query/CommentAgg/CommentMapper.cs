using Domain.CommentAgg;
using Query.CommentAgg.DTOs;

namespace Query.CommentAgg
{
    public static class CommentMapper
	{
		public static List<CommentDto> Map(this List<Comment> comments)
        {
			return comments.Select(c => new CommentDto
			{
				Id = c.Id,
				Content = c.Content,
				CreationDate = c.CreationDate,
				ProductId = c.ProductId,
				Status = c.Status,
				UserId = c.UserId
			}).ToList();
        }
	}
}