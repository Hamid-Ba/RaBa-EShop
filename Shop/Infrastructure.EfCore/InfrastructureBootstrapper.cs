using Domain.CategoryAgg.Repository;
using Domain.CommentAgg.Repository;
using Domain.OrderAgg.Repository;
using Domain.ProductAgg.Repository;
using Domain.RoleAgg.Repository;
using Domain.SellerAgg.Repository;
using Domain.SiteEntities.Repository;
using Domain.UserAgg.Repository;
using Infrastructure.Persistent.Dapper;
using Infrastructure.Persistent.EfCore.CategoryAgg;
using Infrastructure.Persistent.EfCore.CommentAgg;
using Infrastructure.Persistent.EfCore.OrderAgg;
using Infrastructure.Persistent.EfCore.ProductAgg;
using Infrastructure.Persistent.EfCore.RoleAgg;
using Infrastructure.Persistent.EfCore.SellerAgg;
using Infrastructure.Persistent.EfCore.SiteEntities.Repositories;
using Infrastructure.Persistent.EfCore.UserAgg;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Congiure(IServiceCollection service, string connectionString)
        {
            //Configure Repositories
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IRoleRepository, RoleRepository>();
            service.AddTransient<ISellerRepository, SellerRepository>();
            service.AddTransient<ISliderRepository, SliderRepository>();
            service.AddTransient<IBannerRepository, BannerRepository>();
            service.AddTransient<IUserRepository, UserRepository>();

            //Configure Dapper Context
            service.AddTransient(_ => new DapperContext(connectionString));
        }
    }
}