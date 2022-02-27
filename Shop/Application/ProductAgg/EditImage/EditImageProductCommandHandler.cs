using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.ProductAgg.EditImage
{
    public class EditImageProductCommandHandler : IBaseCommandHandler<EditImageProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditImageProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<OperationResult> Handle(EditImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetEntityAsyncBy(request.ProdcutId);
            if (product is null) return OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.ProductGallery, request.ImageName);
            var image = new ProductImage(imageName,request.SeoImage,request.Sequence);

            product.EditImage(request.ImageId,image);
            return OperationResult.Success();
        }
    }

}