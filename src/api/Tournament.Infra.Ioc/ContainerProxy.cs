using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tournament.CrossCutting;
using Tournament.Data.Connectors;
using Tournament.Domain.Contracts;

namespace Tournament.Infra.Ioc
{
    public static class ContainerProxy
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatr()
                    .AddSwagger()
                    .AddAutoMapper()
                    .AddLogging();

            services.Configure<Lambda3MovieOptions>(configuration.GetSection(nameof(Lambda3MovieOptions)));
            services.Configure<ImdbMovieOptions>(configuration.GetSection(nameof(ImdbMovieOptions)));

            services.AddTransient<ILambda3MovieConnectorApi, Lambda3MovieConnectorApi>()
                    .AddTransient<IImdbMovieConnectorApi, ImdbMovieConnectorApi>();

            return services;
        }
    }
}