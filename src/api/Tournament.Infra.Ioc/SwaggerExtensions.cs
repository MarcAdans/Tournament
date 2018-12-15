using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using Tournament.CrossCutting;

namespace Tournament.Infra.Ioc
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = GetOptions(configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options.Version, new Info
                {
                    Title = options.Title,
                    Version = options.Version,
                    Description = options.Description,
                    TermsOfService = options.TermsOfService,
                    Contact = new Contact
                    {
                        Name = options.Contact.Name,
                        Email = options.Contact.Email,
                        Url = options.Contact.Url
                    },
                    License = new License
                    {
                        Name = options.License.Name,
                        Url = options.License.Url
                    }
                });
                SetXmlDocumentation(c);
            });

            return services;
        }

        private static void SetXmlDocumentation(SwaggerGenOptions options)
        {
            var path = PlatformServices.Default.Application.ApplicationBasePath;

            var name = PlatformServices.Default.Application.ApplicationName;

            var xmlDocumentPath = Path.Combine(path, $"{name}.xml");

            if (File.Exists(xmlDocumentPath))
            {
                options.IncludeXmlComments(xmlDocumentPath);
            }
        }

        public static IApplicationBuilder UseConfigSwagger(this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var options = GetOptions(configuration);

                c.SwaggerEndpoint(options.Endpoint, nameof(Tournament));
            });

            return app;
        }

        private static SwaggerConfiguration GetOptions(IConfiguration configuration)
        {
            var result = new SwaggerConfiguration();
            configuration.GetSection(nameof(SwaggerConfiguration)).Bind(result);

            return result;
        }
    }
}