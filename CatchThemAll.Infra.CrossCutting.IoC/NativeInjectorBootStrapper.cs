using CatchThemAll.Application.Interfaces;
using CatchThemAll.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatchThemAll.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICaptureAppService, CaptureAppService>();
        }
    }
}
