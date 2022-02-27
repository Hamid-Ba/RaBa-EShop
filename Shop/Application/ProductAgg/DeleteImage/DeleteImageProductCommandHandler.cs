using Domain.ProductAgg.Repository;
using Framework.Application;

namespace Application.ProductAgg.DeleteImage
{
    internal class DeleteImageProductCommandHandler : IBaseCommandHandler<DeleteImageProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteImageProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<OperationResult> Handle(DeleteImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetEntityAsyncBy(request.ProductId);
            if (product is null) return OperationResult.NotFound();

            product.DeleteImage(request.ImageId);
            await _productRepository.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
