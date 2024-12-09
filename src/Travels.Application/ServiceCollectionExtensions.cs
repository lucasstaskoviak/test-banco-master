using Microsoft.Extensions.DependencyInjection;
using Travels.Application.UseCases.AddRoute;
using Travels.Application.UseCases.DeleteRoute;
using Travels.Application.UseCases.GetRoute;
using Travels.Application.UseCases.GetRouteById;
using Travels.Application.UseCases.UpdateRoute;
using Travels.Application.UseCases.GetCheapestRoute;

namespace Travels.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<AddRouteUseCase>();
            services.AddTransient<GetRouteByIdUseCase>();
            services.AddTransient<GetRouteUseCase>();
            services.AddTransient<DeleteRouteUseCase>();
            services.AddTransient<UpdateRouteUseCase>();
            services.AddTransient<GetCheapestRouteUseCase>();
            
            return services;
        }
    }
}
