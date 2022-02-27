using Framework.Application;
using Framework.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.ProductAgg.EditImage
{
    public record EditImageProductCommand(long ProdcutId, long ImageId, IFormFile ImageFile,string ImageName, SeoImage SeoImage, int Sequence) : IBaseCommand;
}