using Framework.Application;
using Framework.Domain.ValueObjects;

namespace Application.CategoryAgg.Edit
{
    public record EditCategoryCommand(long id, string Title, string Slug, SeoData SeoData) : IBaseCommand;
}