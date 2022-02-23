using Framework.Application;
using Framework.Domain.ValueObjects;

namespace Application.CategoryAgg.Create
{
    public record CreateCategoryCommand(string Title, string Slug, SeoData SeoData) : IBaseCommand;
}