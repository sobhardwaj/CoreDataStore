using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class PlutoRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly IPlutoRepository _plutoRepository;

        private readonly ITestOutputHelper _output;

        public PlutoRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _plutoRepository = fixture.PlutoRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Get_Landmarks_Pluto()
        {
            var lpcNumber = "LP-02039";
            var sut = _plutoRepository.GetPluto(lpcNumber).ToList();

            Assert.NotNull(sut);
            Assert.NotEmpty(sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Get_Landmarks_Pluto_Async()
        {
            var lpcNumber = "LP-02039";
            var results = await _plutoRepository.GetPlutoAsync(lpcNumber);

            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Get_Landmarks_Pluto_Count()
        {
            var lpcNumber = "LP-02039";
            var result = _plutoRepository.GetPlutoCount(lpcNumber);

            Assert.NotEqual(0, result);
        }


        [Fact(DisplayName = "Pluto Count - Async")]
        [Trait("Category", "Integration")]
        public async Task Get_Landmarks_Pluto_Count_Async()
        {
            var lpcNumber = "LP-02039";
            var sut = await _plutoRepository.GetPlutoCountAsync(lpcNumber);

            Assert.NotEqual(0, sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Pluto_Block_Lot_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.Block == 1 && x.Lot == 10).ToList();
            Assert.NotNull(results);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Pluto_BBL_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.BBL == 5080500013).ToList();
            Assert.NotNull(results);
        }
    }
}
