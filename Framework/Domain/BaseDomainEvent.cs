using MediatR;

namespace Framework.Domain
{
    public class BaseDomainEvent : INotification
    {
        public DateTime CreationDate { get; protected set; }

        public BaseDomainEvent() => CreationDate = DateTime.Now;

    }
}