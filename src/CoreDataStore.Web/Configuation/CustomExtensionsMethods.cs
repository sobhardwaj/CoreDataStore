using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreDataStore.Web.Configuation
{
    /// <summary>
    ///
    /// </summary>
    public static class CustomExtensionsMethods
    {
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
                    Title = "ImageGallery.WebAPI",
                    Description = "ImageGallery.WebAPI",
                    Version = "v1",
                    TermsOfService = "None"
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
