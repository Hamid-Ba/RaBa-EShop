using Framework.Application;
using Framework.Domain.Enums;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.SiteEntities.Banners.Create
{
    public record CreateBannerCommand(string Link, IFormFile ImageName, SeoImage SeoImage, BannerPosition Position) : IBaseCommand;
}