using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Test.Fixtures;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Enum;
using Navigator.Common.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LpcReportRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcReportRepository _lpcReportRepository;

        private readonly NYCLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcReportRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _dbContext = fixture.DbContext;
            _lpcReportRepository = fixture.LpcReportRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void LPC_Reports_Exist()
        {
            var results = _lpcReportRepository.GetAll().ToList();
            var count = results.Count;

            Assert.NotNull(results);
            Assert.NotEqual(0, count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Borough_List()
        {
            var results = EnumHelper.EnumToList<Borough>().Select(e => e.GetDescription()).ToList();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Filtered_Paging_List()
        {
            var predicate = PredicateBuilder.True<LpcReport>();
            var request = new LpcReportRequest()
            {
                PageSize = 20,
                Page = 1,
            };

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null,
            };

            var sortingList = new List<SortModel>();
            sortingList.Add(sortModel);

            var results = _lpcReportRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList).ToList();

            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Lamppost_List()
        {
            var results = _dbContext.LPCLamppost.ToList();
            var count = results.Count;

            Assert.NotNull(results);
            Assert.NotEqual(0, count);
        }
    }
}
