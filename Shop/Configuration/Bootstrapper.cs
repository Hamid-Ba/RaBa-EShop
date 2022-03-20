using Application.CategoryAgg;
using Application.CategoryAgg.Create;
using Application.ProductAgg;
using Application.RoleAgg;
using Application.SellerAgg;
using Application.UserAgg;
using Domain.CategoryAgg.Services;
using Domain.ProductAgg.Services;
using Domain.RoleAgg.Services;
using Domain.SellerAgg.Services;
using Domain.UserAgg.Services;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Query.CategoryAgg;

namespace Configuration;

public static class Bootstrapper
{
    public static void Confiure(this IServiceCollection services, string connectionString)
    {
        //Add Repositories Dependencies
        InfrastructureBootstrapper.Congiure(services, connectionString);

        //Add Applications Dependencies
        services.AddMediatR(typeof(CreateCategoryCommand).Assembly);

        //Add Queries Dependencies
        services.AddMediatR(typeof(CategoryMapper).Assembly);

        //Add Fluent Validation Dependencies
        services.AddValidatorsFromAssembly(typeof(CreateCategoryCommandValidator).Assembly);

        //Add Domain Services Dependencies
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IRoleDomainService, RoleDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
    }
}