using Application.SiteEntities.Sliders.Create;
using Application.SiteEntities.Sliders.Edit;
using Framework.Application;
using Query.SiteEntities.Sliders.DTOs;

namespace Presentation.Facade.SiteEntities.Sliders
{
    public interface ISliderFacade
	{
        #region Command
        Task<OperationResult> Edit(EditSliderCommand command);
        Task<OperationResult> Create(CreateSliderCommand command);
        #endregion

        #region Query
        Task<List<SliderDto>> GetAll();
        Task<SliderDto> GetSliderBy(long id);
        #endregion
    }
}