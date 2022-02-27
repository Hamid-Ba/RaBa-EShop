using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.ProductAgg.AddImage
{
    public class AddImageProductCommandHnadler : IBaseCommandHandler<AddImageProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public AddImageProductCommandHnadler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<OperationResult> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetEntityAsyncBy(request.ProdcutId);
            if (product is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageName, DirectoryImages.ProductGallery, null!);

            var image = new ProductImage(imageName, request.SeoImage, request.Sequence);
            product.AddImage(image);

            await _productRepository.SaveChangesAsync();
            return OperationResult.Success();
        }
    }
}