using System.Linq;
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

        [Fact, Trait("Category", "Intergration")]
        public void Get_Landmarks_Pluto()
        {
            var lpcNumber = "LP-02039";
            var results = _plutoRepository.GetPluto(lpcNumber).ToList();

            Assert.NotNull(results);
            Assert.NotEmpty(results);
        }

        [Fact, Trait("Category", "Intergration")]
        public void Get_Landmarks_Pluto_Count()
        {
            var lpcNumber = "LP-02039";
            var result = _plutoRepository.GetPlutoCount(lpcNumber);

            Assert.NotEqual(0, result);
        }

        [Fact, Trait("Category", "Intergration")]
        public void Pluto_Block_Lot_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.Block == 1 && x.Lot == 10).ToList();
            Assert.NotNull(results);
        }

        [Fact, Trait("Category", "Intergration")]
        public void Pluto_BBL_Exist()
        {
            var results = _plutoRepository.FindBy(x => x.BBL == 5080500013).ToList();
            Assert.NotNull(results);
        }
    }
}
