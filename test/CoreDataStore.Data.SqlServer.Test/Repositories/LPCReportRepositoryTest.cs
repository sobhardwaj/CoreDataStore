using System;
using System.Linq;
using CoreDataStore.Data.Helpers;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CoreDataStore.Common.Helpers;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    // Setup Unit Tests - In Memory etc
    //http://www.jerriepelser.com/blog/unit-testing-aspnet5-entityframework7-inmemory-database
    //https://github.com/jerriep/Aspnet5DbContextTesting

    // R# BROKEN in .NET CORE 
    //https://www.jetbrains.com/help/resharper/2016.1/Reference__Windows__Unit_Test_Sessions.html?origin=old_help

    public class LPCReportRepositoryTest
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILPCReportRepository lpcReportRepository;
        private readonly NYCLandmarkContext dbContext;

        public LPCReportRepositoryTest()
        {
            var services = new ServiceCollection();

#warning "Remove Hardcoded DB Connection String"
            services.AddDbContext<NYCLandmarkContext>(options =>
            options.UseSqlServer(@"Data Source=.;Initial Catalog=NycLandmarks;Integrated Security=True"));

            services.AddScoped<ILPCReportRepository, LPCReportRepository>();
            serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();
            lpcReportRepository = serviceProvider.GetRequiredService<ILPCReportRepository>();

        }


        [Fact]
        public void LPC_Reports_Exist()
        {
            var results = lpcReportRepository.GetAll().ToList();
            Assert.NotNull(results);
        }

        [Fact]
        public void Can_Update_LPC_Report()
        {
            var lpcReport = lpcReportRepository.GetSingle(1);
            lpcReport.Name = "Pieter Claesen Wyckoff House X";

            dbContext.SaveChanges();
        }

        [Fact]
        public void Can_Load_LPC_Report()
        {
            var lpcReports = DataLoader.LoadLPCReports(@"./../../data/LPCReport.csv");

            dbContext.LPCReports.AddRange(lpcReports);
            dbContext.SaveChanges();
        }

        [Fact]
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


        [Fact]
        public void Can_Get_Inclueded_Fields()
        {
            var test = dbContext.LPCReports.Include(x => x.Name).ToList();
            var results = lpcReportRepository.AllIncluding(x => x.Name).ToList();
            Assert.NotNull(results);

        }



    }
}
