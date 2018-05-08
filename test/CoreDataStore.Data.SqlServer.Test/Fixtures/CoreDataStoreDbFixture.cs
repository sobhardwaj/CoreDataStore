using System;
using System.IO;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
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
                .AddScoped<ILpcLamppostRepository, LPCLamppostRepository>()
                .AddScoped<ILpcLocationRepository, LPCLocationRepository>()
                .AddScoped<ILpcReportRepository, LPCReportRepository>()
                .AddScoped<IPlutoRepository, PlutoRepository>()
                .BuildServiceProvider();

            DbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();

            LandmarkRepository = serviceProvider.GetRequiredService<ILandmarkRepository>();
            LpcLamppostRepository = serviceProvider.GetRequiredService<ILpcLamppostRepository>();
            LpcLocationRepository = serviceProvider.GetRequiredService<ILpcLocationRepository>();
            LpcReportRepository = serviceProvider.GetRequiredService<ILpcReportRepository>();
            PlutoRepository = serviceProvider.GetRequiredService<IPlutoRepository>();
        }

        public string DbConnection { get; private set; }

        public NYCLandmarkContext DbContext { get; private set; }

        public ILandmarkRepository LandmarkRepository { get; private set; }

        public ILpcLamppostRepository LpcLamppostRepository { get; private set; }

        public ILpcLocationRepository LpcLocationRepository { get; private set; }

        public ILpcReportRepository LpcReportRepository { get; private set; }

        public IPlutoRepository PlutoRepository { get; private set; }

        public void Dispose()
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
