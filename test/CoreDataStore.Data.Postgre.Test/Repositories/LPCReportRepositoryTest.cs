using System;
using System.Linq;
using CoreDataStore.Data.Helpers;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CoreDataStore.Common.Helpers;


namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LPCReportRepositoryTest
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILPCReportRepository lpcReportRepository;
        private readonly NYCLandmarkContext dbContext;

        public LPCReportRepositoryTest()
        {
            var services = new ServiceCollection();

            services.AddDbContext<NYCLandmarkContext>(options =>
            options.UseNpgsql(@"User ID=postgres; Password=password;  Server=localhost;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"));

            services.AddScoped<ILPCReportRepository, LPCReportRepository>();
            serviceProvider = services.BuildServiceProvider();

            dbContext = serviceProvider.GetRequiredService<NYCLandmarkContext>();
            lpcReportRepository = serviceProvider.GetRequiredService<ILPCReportRepository>();

        }


        [Fact]
        public void LPC_Reports_Exist()
        {
            var results = lpcReportRepository.GetAll();
            Assert.NotNull(results);
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
            int batchSize = 1000;

            var landmarks = DataLoader.LoadLandmarks(@"./../../data/Landmarks.csv").ToList();
            foreach (var list in landmarks.Batch(batchSize))
            {
                dbContext.Landmarks.AddRange(list);
                dbContext.SaveChanges();
            }
        }

    }
}
