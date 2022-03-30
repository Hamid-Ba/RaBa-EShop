using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Domain.ProductAgg.Services;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.ProductAgg.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;

        public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService)
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsTrackingAsyncBy(request.Id);
            if (product is null) OperationResult.NotFound();

            var imageName = Uploader.ImageUploader(request.ImageFile, DirectoryImages.Product, request.ImageName);

            product.Edit(request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId, request.Title,
                request.Description, imageName, request.Slug, request.SeoDate, request.SeoImage, _productDomainService);

            List<ProductSpecification> specs = new List<ProductSpecification>();

            request.Specifications.ToList().ForEach(spec =>
            {
                var newSpec = new ProductSpecification(spec.Key, spec.Value);
                specs.Add(newSpec);
            });

            product.AddSepcification(specs);
            await _productRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}