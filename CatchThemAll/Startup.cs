using CatchThemAll.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CatchThemAll
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyInjectionConfiguration();
        }
    }

    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static IHost UseStartup<TStartup>(this IHostBuilder hostBuilder) where TStartup : IStartup
        {
            IConfiguration config = new ConfigurationBuilder().Build();

            if (Activator.CreateInstance(typeof(TStartup)) is not IStartup startup) 
                throw new ArgumentException("Classe Startup.cs inválida!");

            hostBuilder.ConfigureServices((hostBuilder, services) => startup.ConfigureServices(services));
            var app = hostBuilder.Build();

            return app;
        }
    }
}
