using Domain.CommentAgg.Enums;
using Framework.Query;
using Framework.Query.Filter;

namespace Query.CommentAgg.DTOs
{
    public class CommentDto : BaseDto
	{
		public long UserId { get;  set; }
        public string UserFullName { get; set; }
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string Content { get; set; }
		public CommentStatus Status { get; set; }
	}

	public class CommentFilterParam : BaseFilterParam
    {
        public long? UserId { get; set; }
        public CommentStatus? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParam>
    {
        public CommentFilterResult(List<CommentDto> data, CommentFilterParam filterParams) : base(data, filterParams)
        {
        }
    }
}