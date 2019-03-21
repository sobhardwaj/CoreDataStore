using System.Linq;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LpcLocationRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcLocationRepository _lpcLocationRepository;

        private readonly NycLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcLocationRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lpcLocationRepository = fixture.LpcLocationRepository;
            _dbContext = fixture.DbContext;
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
        public void Can_Get_LPCReport()
        {
            var lpNumber = "LP-00871";
            var landmark = _dbContext.LPCReports.Where(x => x.LPNumber == lpNumber).Select(x => x.LPNumber).First();

            Assert.Equal(lpNumber, landmark);
        }
    }
}
