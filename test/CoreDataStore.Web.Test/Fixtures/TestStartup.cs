using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreDataStore.Web.Test.Fixtures
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment CurrentEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddOptions();
            services.AddSingleton(Configuration);

            services.DisplayConfiguration(Configuration);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */

            app.UseMvc();
        }
    }

    internal static class ServiceCollectionExtensions
    {
        public static void DisplayConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine($"Configuration Info");
        }
    }
}
