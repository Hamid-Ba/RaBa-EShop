using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Edit;
using Framework.Application;
using MediatR;
using Query.SiteEntities.Banners.DTOs;
using Query.SiteEntities.Banners.Get;
using Query.SiteEntities.Banners.GetAll;

namespace Presentation.Facade.SiteEntities.Banners
{
    public class BannerFacade : IBannerFacade
	{
        private readonly IMediator _mediator;

        public BannerFacade(IMediator mediator) => _mediator = mediator;

        public async Task<OperationResult> Create(CreateBannerCommand command) => await _mediator.Send(command);

        public async Task<OperationResult> Edit(EditBannerCommand command) => await _mediator.Send(command);

        public async Task<List<BannerDto>> GetAll() => await _mediator.Send(new GetAllBannerQuery());

        public async Task<BannerDto> GetBannerBy(long id) => await _mediator.Send(new GetBannerByIdQuery(id));
        
    }
}