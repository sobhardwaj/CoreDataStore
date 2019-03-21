using System;
using System.IO;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreDataStore.Data.SqlServer.Test.Fixtures
{
    public class CoreDataStoreDbFixture : IDisposable
    {
        public CoreDataStoreDbFixture()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            Console.WriteLine("ENV:" + env);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            DbConnection = builder.GetConnectionString("SqlServer");

            var serviceProvider = new ServiceCollection()
                .AddDbContext<NYCLandmarkContext>(options => options.UseSqlServer(DbConnection))
                .AddScoped<ILandmarkRepository, LandmarkRepository>()
                .AddScoped<ILpcLamppostRepository, LpcLamppostRepository>()
                .AddScoped<ILpcLocationRepository, LpcLocationRepository>()
                .AddScoped<ILpcReportRepository, LpcReportRepository>()
                .AddScoped<IPlutoRepository, PlutoRepository>()
                .AddScoped<ILPCReportService, LpcReportService>()
                .AddScoped<ILandmarkService, LandmarkService>()
                .BuildServiceProvider();

            DbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();

            LandmarkRepository = serviceProvider.GetRequiredService<ILandmarkRepository>();
            LpcLamppostRepository = serviceProvider.GetRequiredService<ILpcLamppostRepository>();
            LpcLocationRepository = serviceProvider.GetRequiredService<ILpcLocationRepository>();
            LpcReportRepository = serviceProvider.GetRequiredService<ILpcReportRepository>();
            PlutoRepository = serviceProvider.GetRequiredService<IPlutoRepository>();

            LPCReportService = serviceProvider.GetRequiredService<ILPCReportService>();
            LandmarkService = serviceProvider.GetRequiredService<ILandmarkService>();

            AutoMapperConfiguration.Configure();
        }

        public string DbConnection { get; }

        public NYCLandmarkContext DbContext { get; }

        public ILandmarkRepository LandmarkRepository { get; }

        public ILpcLamppostRepository LpcLamppostRepository { get; }

        public ILpcLocationRepository LpcLocationRepository { get; }

        public ILpcReportRepository LpcReportRepository { get; }

        public IPlutoRepository PlutoRepository { get; }

        public ILPCReportService LPCReportService { get; }

        public ILandmarkService LandmarkService { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                LandmarkRepository.Dispose();
                LpcLamppostRepository.Dispose();
                LpcLocationRepository.Dispose();
                LpcReportRepository.Dispose();
                PlutoRepository.Dispose();
                DbContext.Dispose();
            }
        }
    }
}
