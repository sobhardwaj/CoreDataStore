using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Domain.Entities;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LpcLamppostRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcLamppostRepository _lamppostRepository;

        private readonly ITestOutputHelper _output;

        public LpcLamppostRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lamppostRepository = fixture.LpcLamppostRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Get_LPC_Lamppost_List()
        {
            var sut = _lamppostRepository.GetAll().ToList();
            var count = sut.Count;

            Assert.NotNull(sut);
            Assert.IsAssignableFrom<IEnumerable<LpcLamppost>>(sut);
            Assert.NotEqual(0, count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Lamppost()
        {
            var postId = 10;
            var sut = _lamppostRepository.GetSingle(x => x.PostId == postId).PostId;

            Assert.Equal(postId, sut);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Can_Update_Lamppost_Properties()
        {
            var postId = 10;
            var result = _lamppostRepository.GetSingle(x => x.PostId == postId);
            result.Borough = "Manhattan";

            _lamppostRepository.UserId = "Unit Test";
            var sut = await _lamppostRepository.UpdateDbEntryAsync(result, d => d.Borough);

            // Assert
            Assert.True(sut);
        }
    }
}
