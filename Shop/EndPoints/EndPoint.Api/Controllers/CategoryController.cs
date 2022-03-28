using Application.CategoryAgg.AddChild;
using Application.CategoryAgg.Create;
using Application.CategoryAgg.Edit;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.CategoryAgg;
using Query.CategoryAgg.DTOs;

namespace EndPoint.Api.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade) => _categoryFacade = categoryFacade;

        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetAll() => QueryResult(await _categoryFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> Get(long id) => QueryResult(await _categoryFacade.GetCategoryBy(id));

        [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<CategoryDto>>> GetChildren(long parentId) => QueryResult(await _categoryFacade.GetCategoryChildrenBy(parentId));

        [HttpPost]
        public async Task<ApiResult> Create(CreateCategoryCommand command) => CommandResult(await _categoryFacade.Create(command));

        [HttpPost("AddChild")]
        public async Task<ApiResult> AddChild(AddChildCategoryCommand command) => CommandResult(await _categoryFacade.AddChild(command));

        [HttpPut]
        public async Task<ApiResult> Edit(EditCategoryCommand command) => CommandResult(await _categoryFacade.Edit(command));
    }
}