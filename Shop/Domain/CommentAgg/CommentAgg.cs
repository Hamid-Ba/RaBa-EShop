using Domain.CommentAgg.Enums;
using Framework.Domain;
using Framework.Domain.Exceptions;

namespace Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Content { get; private set; }
        public CommentStatus Status { get; private set; }

        public Comment(long userId, long productId, string content, CommentStatus status)
        {
            Guard(content);

            UserId = userId;
            ProductId = productId;
            Content = content;
            Status = status;
        }

        public void ChangeStatus(CommentStatus status) => Status = status;

        public void Guard(string content) => NullOrEmptyDomainDataException.CheckString(content, nameof(content));

    }
}