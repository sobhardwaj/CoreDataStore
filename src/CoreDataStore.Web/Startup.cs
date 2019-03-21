using System;
using System.IO;
using System.Net;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using CoreDataStore.Web.Configuration;
using CoreDataStore.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Navigator.Common.Helpers;
using Navigator.Middleware.HttpHeaders;

namespace CoreDataStore.Web
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            using (ConsoleColorContext.Create())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("ASPNETCORE_URLS:{0}", Configuration["ASPNETCORE_URLS"]);
                Console.WriteLine("ASPNETCORE_ENVIRONMENT:{0}", Configuration["ASPNETCORE_ENVIRONMENT"]);
            }
        }

        /// <summary>
        ///  Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices Development - Sqlite.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddConfigurationOptions(Configuration);
            var config = Configuration.Get<ApplicationOptions>();

            var connection = config.ConnectionStrings.Sqlite;
            var connectionString = $"Filename={Path.GetFullPath(connection)}";

            services.AddDbContext<Data.Sqlite.NycLandmarkContext>(options => options.UseSqlite(connectionString));

            // Repositories
            services.AddScoped<ILpcReportRepository, Data.Sqlite.Repositories.LpcReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.Sqlite.Repositories.LandmarkRepository>();
            services.AddScoped<IPlutoRepository, Data.Sqlite.Repositories.PlutoRepository>();
            services.AddScoped<IReferenceRepository, Data.Sqlite.Repositories.ReferenceRepository>();

            ConfigureServices(services);
        }

        /// <summary>
        /// ConfigureServices Staging - PostgreSQL.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddConfigurationOptions(Configuration);
            var config = Configuration.Get<ApplicationOptions>();

            // EnvironmentVariable Exist Override
            var connection = !string.IsNullOrWhiteSpace(Configuration["CONNECTION_PostgreSQL"]) ? Configuration["CONNECTION_PostgreSQL"] : config.ConnectionStrings.PostgreSql;

            services.AddDbContext<Data.Postgre.NycLandmarkContext>(options => options.UseNpgsql(connection));

            // Repositories
            services.AddScoped<ILpcReportRepository, Data.Postgre.Repositories.LpcReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.Postgre.Repositories.LandmarkRepository>();
            services.AddScoped<IPlutoRepository, Data.Postgre.Repositories.PlutoRepository>();
            services.AddScoped<IReferenceRepository, Data.Postgre.Repositories.ReferenceRepository>();

            ConfigureServices(services);
        }

        /// <summary>
        /// ConfigureServices Staging - SqlServer.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddConfigurationOptions(Configuration);
            var config = Configuration.Get<ApplicationOptions>();

            services.AddDbContext<Data.SqlServer.NycLandmarkContext>(options => options.UseSqlServer(config.ConnectionStrings.SqlServer));

            // Repositories
            services.AddScoped<ILpcReportRepository, Data.SqlServer.Repositories.LpcReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.SqlServer.Repositories.LandmarkRepository>();
            services.AddScoped<IPlutoRepository, Data.SqlServer.Repositories.PlutoRepository>();
            services.AddScoped<IReferenceRepository, Data.SqlServer.Repositories.ReferenceRepository>();

            ConfigureServices(services);
        }

        /// <summary>
        /// ConfigureServices - All Configurations
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<ILpcReportService, LpcReportService>();
            services.AddScoped<ILandmarkService, LandmarkService>();
            services.AddScoped<IPlutoService, PlutoService>();

            services.AddCustomSwagger(Configuration);
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddMvc();
        }





        /// <summary>
        /// Configure Development
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void ConfigureDevelopment(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            AppConfig(app, loggerFactory);
        }

        /// <summary>
        /// Configure Staging
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void ConfigureStaging(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(
                          builder =>
                          {
                              builder.Run(
                                async context =>
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                    var error = context.Features.Get<IExceptionHandlerFeature>();
                                    if (error != null)
                                    {
                                        context.Response.AddApplicationError(error.Error.Message);
                                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                    }
                                });
                          });

            AppConfig(app, loggerFactory);
        }

        /// <summary>
        /// Configure Production
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public void ConfigureProduction(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler($"/Home/Error");
            AppConfig(app, loggerFactory);
        }

        private void AppConfig(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            AutoMapperConfiguration.Configure();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseResponseHeaderMiddleware();
            app.UseMvc(ConfigureRoutes);

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var swaggerDocument = $"/swagger/v1/swagger.json";
                options.SwaggerEndpoint(swaggerDocument, "CoreDataStore.Web");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
