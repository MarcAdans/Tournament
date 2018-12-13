using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tournament.Infra.Ioc
{
    internal static class MediatRExtensions
    {
        public static IServiceCollection AddMediatr(
            this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Tournament.Application");

            services.AddMediatR(assembly);

            return services;
        }
    }
}