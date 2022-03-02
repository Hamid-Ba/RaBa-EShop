using Framework.Application;
using Framework.Domain.Enums;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.SiteEntities.Banners.Edit
{
    public record EditBannerCommand(long Id, string Link, IFormFile ImageFile, string ImageName, SeoImage SeoImage, BannerPosition position) : IBaseCommand;
}