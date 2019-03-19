using System.Linq;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LpcLamppostRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcLamppostRepository _lamppostRepository;

        private readonly NYCLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;

        public LpcLamppostRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _dbContext = fixture.DbContext;
            _lamppostRepository = fixture.LpcLamppostRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Get_LPC_Lamppost_List()
        {
            var results = _lamppostRepository.GetAll().ToList();
            var count = results.Count;

            Assert.NotNull(results);
            Assert.NotEqual(0, count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Lamppost()
        {
            var postId = 10;
            var result = _lamppostRepository.GetSingle(x => x.PostId == postId).PostId;

            Assert.Equal(postId, result);
        }
    }
}
