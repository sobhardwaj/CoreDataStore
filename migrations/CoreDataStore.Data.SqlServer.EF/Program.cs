using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Data.SqlServer.EF
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
            var connectionString = Configuration.GetConnectionString("SqlServer");
            Console.WriteLine($"ConnectionString{connectionString}");

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
                _connectionString = Configuration.GetConnectionString("SqlServer");
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder
                        .UseSqlServer(_connectionString);
                }
            }
        }
    }
}
