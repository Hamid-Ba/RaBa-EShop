using Application.ProductAgg.AddImage;
using Application.ProductAgg.Create;
using Application.ProductAgg.DeleteImage;
using Application.ProductAgg.Edit;
using Application.ProductAgg.EditImage;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.ProductAgg;
using Query.ProductAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade) => _productFacade = productFacade;

        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetAll([FromQuery] ProductFilterParam param) => QueryResult(await _productFacade.GetAll(param));

        [HttpGet("{id}")]
        public async Task<ApiResult<ProductDto>> GetBy(long id) => QueryResult(await _productFacade.GetBy(id));

        [HttpGet("{slug}")]
        public async Task<ApiResult<ProductDto>> GetBy(string slug) => QueryResult(await _productFacade.GetBy(slug));

        [HttpPost]
        public async Task<ApiResult> Create([FromForm]CreateProductCommand command) => CommandResult(await _productFacade.Create(command));

        [HttpPost("addImage")]
        public async Task<ApiResult> AddImage([FromForm]AddImageProductCommand command) => CommandResult(await _productFacade.AddImage(command));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm]EditProductCommand command) => CommandResult(await _productFacade.Edit(command));

        [HttpPut("editImage")]
        public async Task<ApiResult> EditImage([FromForm]EditImageProductCommand command) => CommandResult(await _productFacade.EditImage(command));

        [HttpDelete]
        public async Task<ApiResult> DeleteImage(DeleteImageProductCommand command) => CommandResult(await _productFacade.DeleteImage(command));
    }
}