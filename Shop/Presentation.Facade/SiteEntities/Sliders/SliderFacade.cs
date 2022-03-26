using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Framework.Application;
using MediatR;
using Query.SiteEntities.Sliders.DTOs;
using Query.SiteEntities.Sliders.Get;
using Query.SiteEntities.Sliders.GetAll;

namespace Presentation.Facade.SiteEntities.Sliders
{
    public class SliderFacade : ISliderFacade
	{
        private readonly IMediator _mediator;

        public SliderFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Create(CreateSliderCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditSliderCommand command) => await _mediator.Send(command);

        public async Task<List<SliderDto>> GetAll() => await _mediator.Send(new GetAllSliderQuery());

        public async Task<SliderDto> GetSliderBy(long id) => await _mediator.Send(new GetSliderByIdQuery(id));
        
    }
}