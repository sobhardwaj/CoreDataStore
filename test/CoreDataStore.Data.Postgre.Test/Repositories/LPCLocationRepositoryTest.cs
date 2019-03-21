using System.Linq;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LpcLocationRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcLocationRepository _lpcLocationRepository;

        private readonly NycLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcLocationRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _dbContext = fixture.DbContext;
            _lpcLocationRepository = fixture.LpcLocationRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Get_LPC_Locations_List()
        {
            var results = _lpcLocationRepository.GetAll().ToList();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_LPCLocation()
        {
            var lpNumber = "LP-00871";
            var lpcLocation = _dbContext.LPCLocation.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.Equal(lpNumber, lpcLocation);
        }
    }
}
