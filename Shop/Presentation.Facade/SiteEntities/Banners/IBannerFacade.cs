using Application.SiteEntities.Banners.Create;
using Application.SiteEntities.Banners.Edit;
using Framework.Application;
using Query.SiteEntities.Banners.DTOs;

namespace Presentation.Facade.SiteEntities.Banners
{
    public interface IBannerFacade
	{
        #region Command
        Task<OperationResult> Edit(EditBannerCommand command);
		Task<OperationResult> Create(CreateBannerCommand command);
        #endregion

        #region Query
        Task<List<BannerDto>> GetAll();
        Task<BannerDto> GetBannerBy(long id);
        #endregion
    }
}