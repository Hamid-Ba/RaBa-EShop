using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade.CategoryAgg;
using Presentation.Facade.CommentAgg;
using Presentation.Facade.OrderAgg;
using Presentation.Facade.ProductAgg;
using Presentation.Facade.RoleAgg;
using Presentation.Facade.SellerAgg;
using Presentation.Facade.SiteEntities.Banners;
using Presentation.Facade.SiteEntities.Sliders;
using Presentation.Facade.UserAgg;
using Presentation.Facade.UserAgg.UserAddress;

namespace Presentation.Facade
{
    public class FacadeBootstrapper
	{
		public static void Congiure(IServiceCollection service)
        {
			service.AddTransient<ICategoryFacade, CategoryFacade>();
			service.AddTransient<ICommentFacade, CommentFacade>();
			service.AddTransient<IOrderFacade, OrderFacade>();
			service.AddTransient<IProductFacade, ProductFacade>();
			service.AddTransient<IRoleFacade, RoleFacade>();
			service.AddTransient<ISellerFacade, SellerFacade>();
			service.AddTransient<IBannerFacade, BannerFacade>();
			service.AddTransient<ISliderFacade, SliderFacade>();
			service.AddTransient<IUserFacade, UserFacade>();
			service.AddTransient<IUserAddressFacade, UserAddressFacade>();
        }
	}
}