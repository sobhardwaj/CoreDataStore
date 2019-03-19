using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LpcReportRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcReportRepository _lpcReportRepository;

        private readonly NYCLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcReportRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lpcReportRepository = fixture.LpcReportRepository;
            _dbContext = fixture.DbContext;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void LPC_Reports_Exist()
        {
            var results = _lpcReportRepository.GetAll().ToList();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Update_LPC_Report()
        {
            var lpcReport = _lpcReportRepository.GetSingle(1);
            lpcReport.Name = $"Pieter Claesen Wyckoff House X";

            var result = _dbContext.SaveChanges();
            Assert.Equal(0, result);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_LPCReport()
        {
            var lpNumber = "LP-00871";
            var lpcReportNumber = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.Equal(lpNumber, lpcReportNumber);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_LPCReport_Location()
        {
            var lpNumber = "LP-00871";
            var lpcReportNumber = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPCLocation).First();

            Assert.Equal(lpNumber, lpcReportNumber.LPNumber);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Included_Fields()
        {
            var lpNumber = "LP-00871";
            var landmarkCount = 4;

            var landmark = _dbContext.LPCReports.Include(x => x.Landmarks).Where(x => x.LPNumber == lpNumber).Select(x => x).First();

            Assert.Equal(lpNumber, landmark.LPNumber);
            Assert.Equal(landmarkCount, landmark.Landmarks.Count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Paging_List()
        {
            var request = new LpcReportRequest
            {
                PageSize = 20,
                Page = 1,
            };

            var sortingList = new List<SortModel>()
            {
                new SortModel
                {
                    SortColumn = "name",
                    SortOrder = "asc",
                },
            };

            var results = _lpcReportRepository.GetPage(request.Page, request.PageSize, sortingList).ToList();
            Assert.Equal(request.PageSize, results.Count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Lamppost_List()
        {
            var results = _dbContext.LPCLamppost.ToList();
            Assert.NotNull(results);
        }
    }
}
