using System;
using System.IO;
using System.Linq;
using CoreDataStore.Data.Helpers;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LPCReportRepositoryTest
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILPCReportRepository lpcReportRepository;
        private readonly ILPCReportService lbcReportService;
        private readonly NYCLandmarkContext dbContext;

        public LPCReportRepositoryTest()
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


        [Fact(Skip = "ci test")]
        public void LPC_Reports_Exist()
        {
            var results = lpcReportRepository.GetAll().ToList();
            Assert.NotNull(results);
        }

        [Fact(Skip = "ci test")]
        public void Can_Update_LPC_Report()
        {
            var lpcReport = lpcReportRepository.GetSingle(1);
            lpcReport.Name = "Pieter Claesen Wyckoff House X";

            dbContext.SaveChanges();
        }

        [Fact(Skip = "ci test")]
        public void Can_Load_LPC_Report()
        {
            var lpcReports = DataLoader.LoadLPCReports(@"./../../data/LPCReport.csv");

            dbContext.LPCReports.AddRange(lpcReports);
            dbContext.SaveChanges();
        }

        [Fact(Skip = "ci test")]
        public void Can_Load_Landmarks()
        {
            int batchSize = 10000;

            var landmarks = DataLoader.LoadLandmarks(@"./../../data/Landmarks.csv").ToList();
            foreach (var list in landmarks.Batch(batchSize))
            {
                dbContext.Landmarks.AddRange(list);
                dbContext.SaveChanges();
            }
        }


        [Fact(Skip = "ci test")]
        public void Can_Get_LPCReport()
        {
            var lpNumber = "LP-00871";
            var landmark = dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.Equal(lpNumber, landmark);
        }


        [Fact(Skip = "ci test")]
        public void Can_Get_Inclueded_Fields()
        {
            var lpNumber = "LP-00871";
            var landmarkCount = 4;

            var landmark = dbContext.LPCReports.Include(x => x.Landmarks).Where(x => x.LPNumber == lpNumber).Select(x => x).First();

            Assert.Equal(lpNumber, landmark.LPNumber);
            Assert.Equal(landmarkCount, landmark.Landmarks.Count);
        }


        //**** Remove Skip For Testing

        //[Fact(Skip = "ci test")]
        [Fact]
        public void Can_Get_Paging_List()
        {
            int count = 0;
            var request = new LPCReportRequest
            {
                PageSize = 20,
                Page = 1,
            };

            //Implenent Dyanmic Order By
            var results = lpcReportRepository.GetPage(request.Page, request.PageSize, null).ToList();
            Assert.Equal(request.PageSize, results.Count);

        }


        [Fact(Skip = "ci test")]
        public void Can_Get_Filtered_Paging_List()
        {
            int count = 0;
            var request = new LPCReportRequest
            {
                PageSize = 20,
                Page = 1,
                Borough = "Manhattan"
            };

            var results = lbcReportService.GetLPCReports(request, out count).ToList();
            Assert.Equal(request.PageSize, results.Count);

        }


    }
}
