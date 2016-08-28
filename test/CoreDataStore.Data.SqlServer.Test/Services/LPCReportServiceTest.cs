using System;
using System.ComponentModel;
using System.IO;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoreDataStore.Data.SqlServer.Test.Services
{
    public class LPCReportServiceTest
    {

        private readonly IServiceProvider serviceProvider;
        private readonly ILPCReportRepository lpcReportRepository;
        private readonly ILPCReportService lbcReportService;
        private readonly NYCLandmarkContext dbContext;

        public LPCReportServiceTest()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json").Build();

            var connectionStringConfig = builder.Build();
            var dbonnection = connectionStringConfig.GetConnectionString("SqlServer");

            services.AddDbContext<NYCLandmarkContext>(options =>
            options.UseSqlServer(dbonnection));

            services.AddScoped<ILPCReportRepository, LPCReportRepository>();
            services.AddScoped<ILPCReportService, LPCReportService>();
            serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();
            lpcReportRepository = serviceProvider.GetRequiredService<ILPCReportRepository>();
            lbcReportService = serviceProvider.GetRequiredService<ILPCReportService>();

            AutoMapperConfiguration.Configure();
        }

        [Category("SQL-IntergrationTest")]
        [Fact(Skip = "ci test")]
        public void LPC_Reports_Exist()
        {
            //var totalRecords = 0;
            //var request = new LPCReportRequest
            //{
            //    PageSize = 20,
            //    Page = 1,
            //    SortColumn = "name",
            //    SortOrder = "asc",
            //};

            ////var results = lbcReportService.GetLPCReports(request, out totalRecords);

            ////Assert.NotNull(results);
        }






    }
}
