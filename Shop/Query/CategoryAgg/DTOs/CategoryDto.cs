using Framework.Domain.ValueObjects;
using Framework.Query;

namespace Query.CategoryAgg.DTOs
{
    public class CategoryDto : BaseDto
	{
        public string Title { get;  set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public long? ParentId { get; set; }

        public List<CategoryDto> Children { get; set; }
    }

    //public class CategoryChildrenDto : BaseDto
    //{
    //    public string Title { get; set; }
    //    public string Slug { get; set; }
    //    public SeoData SeoData { get; set; }
    //    public long? ParentId { get; set; }

    //    public List<SecondaryCategoryChildren> Children { get; set; }
    //}

    //public class SecondaryCategoryChildren : BaseDto
    //{
    //    public string Title { get; set; }
    //    public string Slug { get; set; }
    //    public SeoData SeoData { get; set; }
    //    public long? ParentId { get; set; }
    //}
}