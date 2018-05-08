using System.Linq;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Interfaces;
using Xunit;
using CoreDataStore.Data.Filters;
using System.Collections.Generic;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using Microsoft.EntityFrameworkCore;
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
            _output = output;
        }


        [Fact, Trait("Category", "Intergration")]
        public void LPC_Reports_Exist()
        {
            var results = _lpcReportRepository.GetAll().ToList();
            Assert.NotNull(results);
        }


        //[SkippableFact, Trait("Category", "Intergration")]
        public void Can_Update_LPC_Report()
        {
            var lpcReport = _lpcReportRepository.GetSingle(1);
            lpcReport.Name = "Pieter Claesen Wyckoff House X";

            var result = _dbContext.SaveChanges();
            Assert.NotNull(result);
        }


        //[SkippableFact, Trait("Category", "Intergration")]
        public void Can_Get_LPCReport()
        {
            var lpNumber = "LP-00871";
            var lpcReportNumber = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.Equal(lpNumber, lpcReportNumber);
        }


        //[SkippableFact, Trait("Category", "Intergration")]
        public void Can_Get_LPCReport_Location()
        {
            var lpNumber = "LP-00871";
            var lpcReportNumber = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPCLocation).First();

            Assert.Equal(lpNumber, lpcReportNumber.LPNumber);
        }


        //[SkippableFact, Trait("Category", "Intergration")]
        public void Can_Get_Included_Fields()
        {
            var lpNumber = "LP-00871";
            var landmarkCount = 4;

            var landmark = _dbContext.LPCReports.Include(x => x.Landmarks).Where(x => x.LPNumber == lpNumber).Select(x => x).First();

            Assert.Equal(lpNumber, landmark.LPNumber);
            Assert.Equal(landmarkCount, landmark.Landmarks.Count);
        }

        //[Fact, Trait("Category", "Intergration")]
        public void Can_Get_Paging_List()
        {
            //int count = 0;
            var request = new LPCReportRequest
            {
                PageSize = 20,
                Page = 1,
            };

            var sortingList = new List<SortModel>()
            {
                new SortModel
                {
                    SortColumn = "name",
                    SortOrder = "asc"
                }
            };

            var results = _lpcReportRepository.GetPage(request.Page, request.PageSize, sortingList).ToList();
            Assert.Equal(request.PageSize, results.Count);

        }

        //[SkippableFact, Trait("Category", "Intergration")]
        public void Can_Get_Lamppost_List()
        {
            var results = _dbContext.LPCLamppost.ToList();
            Assert.NotNull(results);
        }
    }
}
