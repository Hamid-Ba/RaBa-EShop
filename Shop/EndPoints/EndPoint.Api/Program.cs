using Configuration;
using EndPoint.Api.Infrastructures.ApiTools;
using Framework.Application;
using Framework.Application.SecurityUtil.Hashing;
using Framework.Presentation.Api;
using Framework.Presentation.Api.JwtTools;
using Framework.Presentation.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
    ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    Status = ApiStatusCode.BadRequest,
                    Message = Tools.HandleBadRequestErrors(context)
                }
            };
            return new BadRequestObjectResult(result);
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Confiure(builder.Configuration.GetConnectionString("Default"));
FrameworkBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IJwtHelper, JwtHelper>();
builder.Services.AddTransient<CustomJwtValidation>();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseApiCustomExceptionHandler();


app.MapControllers();

app.Run();