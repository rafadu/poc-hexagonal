using Adapter.Database.InMemory.Repositories;
using Domain.Ports.Driven;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Database.InMemory
{
    public static class AdapterDatabaseModuleDependency
    {
        public static IServiceCollection AddDatabaseModule(this IServiceCollection services){
            services.AddSingleton<IAdapterDatabasePortService,ToDoRepository>();
            return services;
        }
    }
}