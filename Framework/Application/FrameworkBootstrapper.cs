using Framework.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application
{
    public class FrameworkBootstrapper
	{
		public static void Init(IServiceCollection service)
		{
			service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
		}
	}
}