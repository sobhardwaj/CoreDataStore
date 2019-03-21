using System;
using System.IO;
using System.Reflection;
using CoreDataStore.Web.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreDataStore.Web.Extensions
{
    /// <summary>
    /// Add ConfigurationOptions.
    /// </summary>
    public static class CustomExtensionsMethods
    {
        /// <summary>
        /// Configuration Options.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration
            services.AddOptions();
            services.Configure<ApplicationOptions>(configuration);
            services.AddSingleton(configuration);

            return services;
        }

        /// <summary>
        /// Swagger Configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "CoreDataStore.Web",
                    Description = "CoreDataStore.Web",
                    Version = "v1",
                    TermsOfService = "None",
                });
                options.IncludeXmlComments(GetXmlCommentsPath());
            });

            return services;
        }

        /// <summary>
        ///  Swagger Documentation.
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            var basePath = AppContext.BaseDirectory;
            var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            var fileName = Path.GetFileName(assemblyName + ".xml");

            return Path.Combine(basePath, fileName);
        }
    }
}
