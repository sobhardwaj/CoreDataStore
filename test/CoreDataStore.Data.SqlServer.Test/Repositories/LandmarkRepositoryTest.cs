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
    public class LandmarkRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILandmarkRepository _landmarkRepository;

        private readonly NycLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LandmarkRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _landmarkRepository = fixture.LandmarkRepository;
            _dbContext = fixture.DbContext;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Landmark()
        {
            var id = 100;

            // Act
            var sut = _landmarkRepository.GetSingle(id);

            Assert.NotNull(sut);
        }

        [Fact(DisplayName = "Landmarks Included_Fields", Skip = "Slow")]
        [Trait("Category", "Integration")]
        public void Can_Get_Included_Fields()
        {
            var lpNumber = "LP-02039";
            var landmarks = _landmarkRepository.AllIncluding(x => x.LPCReport)
                              .Where(x => x.LP_NUMBER == lpNumber).Select(x => x).ToList();

            var landmark = landmarks.First();
            Assert.Equal(lpNumber, landmark.LP_NUMBER);

            var lpcReport = landmark.LPCReport;

            Assert.NotNull(lpcReport);
            Assert.IsType<LpcReport>(lpcReport);
        }

        [Fact(DisplayName = "Landmarks Included_Fields Async", Skip = "All Records")]
        [Trait("Category", "Integration")]
        public async Task Can_Get_Included_Fields_Async()
        {
            // Act
            var sut = await _landmarkRepository.AllIncludingAsync(x => x.LPCReport);

            // Assert
            Assert.IsType<List<Landmark>>(sut);

            var landmark = sut.First();
            var lpcReport = landmark.LPCReport;

            Assert.NotNull(lpcReport);
            Assert.IsType<LpcReport>(lpcReport);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Filtered_Paging_List()
        {
            var predicate = PredicateBuilder.True<Landmark>();
            var request = new LandmarkRequest()
            {
                PageSize = 20,
                Page = 1,
            };

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null,
            };

            var sortingList = new List<SortModel> { sortModel };

            var results = _landmarkRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);

            Assert.NotNull(results);
        }
    }
}
