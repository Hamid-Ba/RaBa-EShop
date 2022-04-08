using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade.CategoryAgg;
using Presentation.Facade.CommentAgg;
using Presentation.Facade.OrderAgg;
using Presentation.Facade.ProductAgg;
using Presentation.Facade.RoleAgg;
using Presentation.Facade.SellerAgg;
using Presentation.Facade.SellerAgg.Inventories;
using Presentation.Facade.SiteEntities.Banners;
using Presentation.Facade.SiteEntities.Sliders;
using Presentation.Facade.UserAgg;
using Presentation.Facade.UserAgg.UserAddress;

namespace Presentation.Facade
{
    public static class FacadeBootstrapper
	{
		public static void FacadeCongiure(this IServiceCollection service)
        {
			service.AddScoped<ICategoryFacade, CategoryFacade>();
			service.AddScoped<ICommentFacade, CommentFacade>();
			service.AddScoped<IOrderFacade, OrderFacade>();
			service.AddScoped<IProductFacade, ProductFacade>();
			service.AddScoped<IRoleFacade, RoleFacade>();
			service.AddScoped<ISellerFacade, SellerFacade>();
			service.AddScoped<IInventoryFacade, InventoryFacade>();
			service.AddScoped<IBannerFacade, BannerFacade>();
			service.AddScoped<ISliderFacade, SliderFacade>();
			service.AddScoped<IUserFacade, UserFacade>();
			service.AddScoped<IUserAddressFacade, UserAddressFacade>();
        }
	}
}