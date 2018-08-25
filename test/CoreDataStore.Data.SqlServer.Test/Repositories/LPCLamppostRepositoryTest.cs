using System.Linq;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LpcLamppostRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcLamppostRepository _lamppostRepository;

        private readonly NYCLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;
        public LpcLamppostRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lamppostRepository = fixture.LpcLamppostRepository;
            _output = output;
        }

        [Fact, Trait("Category", "Intergration")]
        public void Get_LPC_Lamppost_List()
        {
            var results = _lamppostRepository.GetAll().ToList();
            var count = results.Count();

            Assert.NotNull(results);
            Assert.NotEqual(0, count);
        }

        [Fact(Skip = "TODO")]
        [Trait("Category", "Intergration")]
        public void Can_Get_Lamppost()
        {
            var postId = 10;
            var result = _lamppostRepository.GetSingle(x => x.PostId == postId).PostId;

            Assert.Equal(postId, result);
        }

        [Fact(Skip = "TODO")]
        [Trait("Category", "Intergration")]
        public void Can_Update_Lamppost_Properties()
        {
            var postId = 10;
            var result = _lamppostRepository.GetSingle(x => x.PostId == postId);
            result.Borough = "Manhattan";

            _lamppostRepository.UserId = "Unit Test";
            _lamppostRepository.UpdateDbEntryAsync(result, d => d.Borough);
        }
    }

}
