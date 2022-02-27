using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.ProductAgg.AddImage
{
    public record AddImageProductCommand(long ProdcutId, IFormFile ImageName, SeoImage SeoImage, int Sequence) : IBaseCommand;
}