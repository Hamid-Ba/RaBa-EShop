using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.SiteEntities.Sliders.Edit
{
    public record EditSliderCommand(long Id, string Title, string Link, IFormFile ImageFile,string ImageName, SeoImage SeoImage) : IBaseCommand;
}