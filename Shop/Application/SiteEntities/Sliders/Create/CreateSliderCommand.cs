using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.SiteEntities.Sliders.Create
{
    public record CreateSliderCommand(string Title, string Link, IFormFile ImageName, SeoImage SeoImage) : IBaseCommand;
}