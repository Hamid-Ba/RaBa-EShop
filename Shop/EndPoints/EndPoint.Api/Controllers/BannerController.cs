using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Edit;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SiteEntities.Banners;
using Query.SiteEntities.Banners.DTOs;

namespace EndPoint.Api.Controllers
{
    public class BannerController : BaseApiController
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade) => _bannerFacade = bannerFacade;

        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetAll() => QueryResult(await _bannerFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<BannerDto>> GetBy(long id) => QueryResult(await _bannerFacade.GetBannerBy(id));

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateBannerCommand command) => CommandResult(await _bannerFacade.Create(command));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditBannerCommand command) => CommandResult(await _bannerFacade.Edit(command));

    }
}