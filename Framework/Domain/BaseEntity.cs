namespace Framework.Domain
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime DeleteDate { get; private set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            IsDelete = false;
        }

        public virtual void Delete()
        {
            DeleteDate = DateTime.Now;
            IsDelete = true;
        }
    }
}