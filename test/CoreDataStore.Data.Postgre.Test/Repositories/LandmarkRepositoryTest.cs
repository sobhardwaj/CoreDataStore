using System.Collections.Generic;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.Postgre.Test.Fixtures;
using CoreDataStore.Domain.Entities;
using Navigator.Common.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.Postgre.Test.Repositories
{
    public class LandmarkRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILandmarkRepository _landmarkRepository;

        private readonly ITestOutputHelper _output;

        public LandmarkRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _landmarkRepository = fixture.LandmarkRepository;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Landmark()
        {
            var id = 100;
            var result = _landmarkRepository.GetSingle(id);
            Assert.NotNull(result);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Filtered_Paging_List()
        {
            var predicate = PredicateBuilder.True<Landmark>();
            var request = new LandmarkRequest()
            {
                PageSize = 20,
                Page = 1,
            };

            var sortModel = new SortModel
            {
                SortColumn = !string.IsNullOrEmpty(request.SortColumn) ? request.SortColumn : null,
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null,
            };

            var sortingList = new List<SortModel>();
            sortingList.Add(sortModel);

            var results = _landmarkRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);

            Assert.NotNull(results);
        }
    }
}
