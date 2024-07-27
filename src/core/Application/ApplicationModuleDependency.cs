using Application.Services;
using Domain.Ports.Driving;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<IApiPortService,ApiPortService>();
            return services;
        }
    }
}