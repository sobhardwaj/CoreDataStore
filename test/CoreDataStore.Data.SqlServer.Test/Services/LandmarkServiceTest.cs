using System.Linq;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Services
{
    public class LandmarkServiceTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILandmarkService _landmarkService;

        private readonly ITestOutputHelper _output;

        public LandmarkServiceTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _landmarkService = fixture.LandmarkService;
            _output = output;
        }

        [Fact(DisplayName = "Landmark_Paging")]
        [Trait("Category", "Integration")]
        public void Can_Get_Landmark_Paging()
        {
            var landmarkRequest = new LandmarkRequest { Page = 1, PageSize = 20 };

            // Act
            var sut = _landmarkService.GetLandmarks(landmarkRequest);

            Assert.NotNull(sut);
            Assert.IsAssignableFrom<PagedResultModel<LandmarkModel>>(sut);

            var item = sut.Results.First();
            Assert.NotNull(item);
            Assert.IsType<LandmarkModel>(item);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Street_List()
        {
            string lpNumber = "LP-02039";

            var results = _landmarkService.GetLandmarkStreets(lpNumber);
            Assert.NotNull(results);
        }
    }
}
