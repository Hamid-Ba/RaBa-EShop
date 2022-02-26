using Domain.ProductAgg;
using Domain.ProductAgg.Repository;
using Domain.ProductAgg.Services;
using Framework.Application;
using Framework.Application.Utils;

namespace Application.ProductAgg.Create
{
    internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;

        public CreateProductCommandHandler(IProductRepository productRepository, IProductDomainService productDomainService)
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = Uploader.ImageUploader(request.ImageName, DirectoryImages.Product, null!);

            var product = new Product(request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId, request.Title,
                request.Description, imageName, request.Slug, request.SeoDate, request.SeoImage, _productDomainService);

            await _productRepository.AddEntityAsync(product);

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