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

		public static CommentDto Map(this Comment? comment)
        {
			if (comment is null) return null;

			return new CommentDto
			{
				Id = comment.Id,
				Content = comment.Content,
				CreationDate = comment.CreationDate,
				ProductId = comment.ProductId,
				Status = comment.Status,
				UserId = comment.UserId
			};
		}
	}
}