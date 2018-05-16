using System.Linq;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.Postgre.Test.Repositories
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
        public void Pluto_Block_Lot_Exist()
        {
            int block = 1096;
            int lot = 54;

            var result = _plutoRepository.FindBy(x => x.Block == block && x.Lot == lot).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal(block, result.Block);
            Assert.Equal(lot, result.Lot);
        }

        [Fact, Trait("Category", "Intergration")]
        public void Pluto_BBL_Exist()
        {
            long bbl = 5080500013;
            var result = _plutoRepository.FindBy(x => x.BBL == bbl).FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal("10307", result.ZipCode);
            Assert.Equal(bbl, bbl);
        }
    }
}
