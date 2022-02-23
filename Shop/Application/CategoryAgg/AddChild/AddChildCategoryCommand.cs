using Framework.Application;
using Framework.Domain.ValueObjects;

namespace Application.CategoryAgg.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string Title, string Slug, SeoData SeoData) : IBaseCommand;
}