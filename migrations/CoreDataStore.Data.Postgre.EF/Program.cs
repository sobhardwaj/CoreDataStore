using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Data.Postgre.EF
{
    public static class Program
    {
        /// <summary>
        ///
        /// </summary>
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true)
            .Build();

        static void Main(string[] args)
        {
            using (var db = new NycLandmarkContextMock())
            {
                db.Database.EnsureCreated();
            }
        }

        public class NycLandmarkContextMock : NycLandmarkContext
        {
            private readonly string _connectionString;

            public NycLandmarkContextMock()
            {
                _connectionString = Configuration.GetConnectionString("PostgreSql");
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .UseNpgsql(_connectionString);
            }
        }
    }
}
