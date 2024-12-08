using Microsoft.Extensions.DependencyInjection;
using Travels.Application.UseCases.AddRoute;
using Travels.Application.UseCases.GetCheapestRoute;

namespace Travels.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<AddRouteHandler>();
            services.AddTransient<GetCheapestRouteHandler>();
            
            return services;
        }
    }
}
