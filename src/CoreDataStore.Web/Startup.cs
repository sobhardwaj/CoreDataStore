using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Web.Model;
using CoreDataStore.Web.Repositories;

using Microsoft.AspNet.Builder;

using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace CoreDataStore.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Production:SqliteConnectionString"];
            services.AddEntityFramework()
                    .AddSqlite()
                    .AddDbContext<DataEventRecordContext>(options => options.UseSqlite(connection));

            services.AddMvc();
            services.AddScoped<IDataAccessProvider, DataEventRecordRepository>();

        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        public IConfigurationRoot Configuration { get; set; }
    }
}
