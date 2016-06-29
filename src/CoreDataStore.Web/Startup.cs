using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Data.Interfaces;
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
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                //.AddJsonFile("config.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                .AllowAnyMethod()
                                                                .AllowAnyHeader()));

            var prodConnection = Configuration["ConnectionStrings:Sqlite"];
            services.AddDbContext<Data.Sqlite.NYCLandmarkContext>(options => options.UseSqlite(prodConnection));

            // Repositories
            services.AddScoped<ILPCReportRepository, Data.Sqlite.Repositories.LPCReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.Sqlite.Repositories.LandmarkRepository>();
            services.AddScoped<IReferenceRepository, Data.Sqlite.Repositories.ReferenceRepository>();

            ConfigService(services);
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                .AllowAnyMethod()
                                                                .AllowAnyHeader()));

            var prodConnection = Configuration["ConnectionStrings:PostgreSQL"];
            services.AddDbContext<Data.Postgre.NYCLandmarkContext>(options => options.UseNpgsql(prodConnection));
            
            // Repositories
            services.AddScoped<ILPCReportRepository, Data.Postgre.Repositories.LPCReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.Postgre.Repositories.LandmarkRepository>();
            services.AddScoped<IReferenceRepository, Data.Postgre.Repositories.ReferenceRepository>();

            ConfigService(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader()));

            var devConnection = Configuration["ConnectionStrings:SqlServer"];
            services.AddDbContext<Data.SqlServer.NYCLandmarkContext>(options => options.UseSqlServer(devConnection));

            // Repositories
            services.AddScoped<ILPCReportRepository, Data.SqlServer.Repositories.LPCReportRepository>();
            services.AddScoped<ILandmarkRepository, Data.SqlServer.Repositories.LandmarkRepository>();
            services.AddScoped<IReferenceRepository, Data.SqlServer.Repositories.ReferenceRepository>();

            ConfigService(services);
        }




        private void ConfigService(IServiceCollection services)
        { 
            services.AddCors();
            services.AddMvc();

            //services.AddSwaggerGen();
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "Core DataStore API",
            //        Description = "Core DataStore API",
            //        TermsOfService = "None"
            //    });
            //});

            services.ConfigureSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();  
            });

            // Services
            services.AddScoped<ILPCReportService, LPCReportService>();
            services.AddScoped<ILandmarkService, LandmarkService>();

        }

        public void ConfigureDevelopment(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            //app.UseDatabaseErrorPage();

            AppConfig(app, loggerFactory);
        }

        public void ConfigureStaging(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler("/Home/Error");

            AppConfig(app, loggerFactory);
        }

        public void ConfigureProduction(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler("/Home/Error");

            AppConfig(app, loggerFactory);
        }




        private void AppConfig(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddProvider(new SqlLoggerProvider());
            loggerFactory.AddDebug();

            AutoMapperConfiguration.Configure();

            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            //app.UseSwaggerGen();
            //app.UseSwaggerUi();

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }

    }
}
