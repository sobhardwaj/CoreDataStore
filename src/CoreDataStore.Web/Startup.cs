using CoreDataStore.Data.Sqlite;
using CoreDataStore.Data.Sqlite.Repositories;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.SwaggerGen.Generator;
using System.Reflection;
using CoreDataStore.Data.Sqlite.Repositories.Abstract;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;

namespace CoreDataStore.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var prodConnection = Configuration["Production:SqliteConnectionString"];
            var devlconnection = Configuration["Development:SqliteConnectionString"];

            services.AddDbContext<NYCLandmarkContext>(options =>
               options.UseSqlite(prodConnection, b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name)));

            services.AddDbContext<DataEventRecordContext>(options =>
               options.UseSqlite(devlconnection, b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name)));

            services.AddDbContext<BloggingContext>(options =>
                options.UseSqlite(devlconnection, b => b.MigrationsAssembly(GetType().GetTypeInfo().Assembly.GetName().Name)));


            JsonOutputFormatter jsonOutputFormatter = new JsonOutputFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };


            services.AddMvc(
                 options =>
                 {
                     options.OutputFormatters.Clear();
                     options.OutputFormatters.Insert(0, jsonOutputFormatter);
                 }
             );

            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Core DataStore API",
                    Description = "Core DataStore API",
                    TermsOfService = "None"
                });
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();  
            });

            // Repositories
            services.AddScoped<IDataAccessProvider, DataEventRecordRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ILPCReportRepository, LPCReportRepository>();
            services.AddScoped<IReferenceRepository, ReferenceRepository>();

            // Services
            services.AddScoped<ILPCReportService, LPCReportService>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddProvider(new SqlLoggerProvider());
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            AutoMapperConfiguration.Configure();

            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            app.UseSwaggerGen();
            app.UseSwaggerUi();

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }

    }
}
