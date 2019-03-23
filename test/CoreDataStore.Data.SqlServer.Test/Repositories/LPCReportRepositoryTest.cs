using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Domain.Entities;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LpcReportRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcReportRepository _lpcReportRepository;

        private readonly NycLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcReportRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lpcReportRepository = fixture.LpcReportRepository;
            _dbContext = fixture.DbContext;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void LPC_Reports_All()
        {
            var results = _lpcReportRepository.GetAll().ToList();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task LPC_Reports_All_Async()
        {
            var results = await _lpcReportRepository.GetAllAsync();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void LPC_Report()
        {
            var sut = _lpcReportRepository.GetSingle(1);

            Assert.NotNull(sut);
            Assert.IsType<LpcReport>(sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void LPC_Report_By_LpcId_Include_Landmarks()
        {
            var lpNumber = "LP-00871";
            var predicate = PredicateBuilder.True<LpcReport>();
            predicate = predicate.And(x => x.LPNumber == lpNumber);

            var sut = _lpcReportRepository.GetSingle(predicate, e => e.Landmarks);

            Assert.NotNull(sut);
            Assert.IsType<LpcReport>(sut);
            Assert.IsType<List<Landmark>>(sut.Landmarks);
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
            var sut = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.NotNull(sut);
            Assert.Equal(lpNumber, sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Can_Get_LPCReport_Async()
        {
            var lpNumber = "LP-00871";
            var sut = await _lpcReportRepository.FindByAsync(x => x.LPNumber == lpNumber);

            Assert.NotNull(sut);
            Assert.IsType<List<LpcReport>>(sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Can_Get_Single_LPCReport_By_Id_Async()
        {
            var sut = await _lpcReportRepository.GetSingleAsync(1);

            Assert.NotNull(sut);
            Assert.IsType<LpcReport>(sut);
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

            var landmark = _lpcReportRepository.AllIncluding(x => x.Landmarks).Where(x => x.LPNumber == lpNumber).Select(x => x).First();

            Assert.Equal(lpNumber, landmark.LPNumber);
            Assert.Equal(landmarkCount, landmark.Landmarks.Count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Can_Get_Count_Async()
        {
            var lpNumber = "LP-00871";

            var count = await _lpcReportRepository.GetCountAsync(x => x.LPNumber == lpNumber);
            Assert.True(1 == count);
        }

        [Fact(DisplayName = "LPC Reports Include")]
        [Trait("Category", "Integration")]
        public async Task Can_Get_Included_Fields_Async()
        {
            var lpNumber = "LP-00871";
            var landmarkCount = 4;

            var sut = await _lpcReportRepository.AllIncludingAsync(x => x.Landmarks);
            var landmark = sut.Where(x => x.LPNumber == lpNumber).Select(x => x).First();

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
