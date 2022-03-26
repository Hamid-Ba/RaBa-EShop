using System;
using Application.ProductAgg.AddImage;
using Application.ProductAgg.Create;
using Application.ProductAgg.DeleteImage;
using Application.ProductAgg.Edit;
using Application.ProductAgg.EditImage;
using Framework.Application;
using MediatR;
using Query.ProductAgg.DTOs;
using Query.ProductAgg.GetAll;
using Query.ProductAgg.GetById;
using Query.ProductAgg.GetBySlug;

namespace Presentation.Facade.ProductAgg
{
    public class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddImage(AddImageProductCommand command) =>await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateProductCommand command) =>await _mediator.Send(command);

        public async Task<OperationResult> DeleteImage(DeleteImageProductCommand command) =>await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditProductCommand command) =>await _mediator.Send(command);

        public async Task<OperationResult> EditImage(EditImageProductCommand command) =>await _mediator.Send(command);

        public async Task<ProductFilterResult> GetAll(ProductFilterParam filter) => await _mediator.Send(new GetAllProductsQuery(filter));

        public async Task<ProductDto> GetBy(string slug) => await _mediator.Send(new GetProductBySlugQuery(slug));

        public async Task<ProductDto> GeyBy(long id) => await _mediator.Send(new GetProductByIdQuery(id));
        
    }
}