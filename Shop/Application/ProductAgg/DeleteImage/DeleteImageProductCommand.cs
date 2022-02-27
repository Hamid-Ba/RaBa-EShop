using Framework.Application;

namespace Application.ProductAgg.DeleteImage
{
    public record DeleteImageProductCommand(long ProductId,long ImageId) : IBaseCommand;
}