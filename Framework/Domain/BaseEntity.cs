namespace Common.Domain
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; }
        public bool IsDelete { get; private set; }

        public BaseEntity()
        {
            CreationDate = new DateTime();
            IsDelete = false;
        }
    }
}