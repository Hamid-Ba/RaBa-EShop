using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Domain.RoleAgg.Enums;
using EndPoint.Api.Infrastructures.Securities;
using Framework.Presentation.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.SiteEntities.Sliders;
using Query.SiteEntities.Sliders.DTOs;

namespace EndPoint.Api.Controllers
{
    [PermissionChecker(Permission.CRUD_Slider)]
    public class SliderController : BaseApiController
    {
        private readonly ISliderFacade _sliderFacade;

        public SliderController(ISliderFacade sliderFacade) => _sliderFacade = sliderFacade;

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<List<SliderDto>>> GetAll() => QueryResult(await _sliderFacade.GetAll());

        [HttpGet("{id}")]
        public async Task<ApiResult<SliderDto>> GetBy(long id) => QueryResult(await _sliderFacade.GetSliderBy(id));

        [HttpPost]
        public async Task<ApiResult> Create([FromForm] CreateSliderCommand command) => CommandResult(await _sliderFacade.Create(command));

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditSliderCommand command) => CommandResult(await _sliderFacade.Edit(command));

    }
}