using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Service.Interfaces;
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
