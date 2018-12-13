using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Tournament.Infra.Ioc
{
    public static class ContainerProxy
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatr()
                    .AddSwagger()
                    .AddAutoMapper()
                    .AddLogging();
                    //.AddTransient<IGoogleMapsConnector, GoogleMapsConnector>()
                    //.AddTransient<IGoogleMapsConfiguration, GoogleMapsConfiguration>();

            return services;
        }
    }
}