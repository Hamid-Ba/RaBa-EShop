using Common.Domain;
using Common.Domain.Exceptions;
using Domain.CommentAgg.Enums;

namespace Domain.CommentAgg
{
    public class CommentAgg : AggregateRoot
    {
        public long UserId { get; private set; }
        public long ProductId { get; private set; }
        public string Content { get; private set; }
        public CommentStatus Status { get; private set; }

        public CommentAgg(long userId, long productId, string content, CommentStatus status)
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