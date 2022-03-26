using Application.CategoryAgg.AddChild;
using Application.CategoryAgg.Create;
using Application.CategoryAgg.Edit;
using Framework.Application;
using MediatR;
using Query.CategoryAgg.DTOs;
using Query.CategoryAgg.GetAll;
using Query.CategoryAgg.GetById;
using Query.CategoryAgg.GetChildrenById;

namespace Presentation.Facade.CategoryAgg
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;

        public CategoryFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> AddChild(AddChildCategoryCommand command) =>await _mediator.Send(command);

        public async Task<OperationResult> Create(CreateCategoryCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditCategoryCommand command) => await _mediator.Send(command);

        public async Task<List<CategoryDto>> GetAll() => await _mediator.Send(new GetAllCategoryQuery());

        public async Task<CategoryDto> GetCategoryById(long id) => await _mediator.Send(new GetCategoryByIdQuery(id));

        public async Task<List<CategoryDto>> GetCategoryChildrenById(long parentId) => await _mediator.Send(new GetCategoryChildrenByIdQuery(parentId));
    }
}