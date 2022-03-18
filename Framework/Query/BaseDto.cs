namespace Framework.Query
{
    public class BaseDto
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DeleteDate { get; set; }
    }

}