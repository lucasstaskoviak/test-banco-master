using Microsoft.Extensions.DependencyInjection;
using Travels.Application.Interfaces.Repositories;
using Travels.Infrastructure.Repositories;

namespace Travels.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IRouteRepository, RouteRepository>();
            
            return services;
        }
    }
}
