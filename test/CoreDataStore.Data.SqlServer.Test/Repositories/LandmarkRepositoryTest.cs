using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Extensions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Repositories
{
    public class LandmarkRepositoryTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILandmarkRepository _landmarkRepository;

        private readonly NYCLandmarkContext _dbContext;

        private readonly ITestOutputHelper _output;
        public LandmarkRepositoryTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _landmarkRepository = fixture.LandmarkRepository;
            _output = output;
        }


 [SkippableFact]
       // [Fact, Trait("Category", "Intergration")]
        public void Can_Get_Landmark()
        {
            var id = 100;
            var result = _landmarkRepository.GetSingle(id);
            Assert.NotNull(result);
        }

        //[Fact, Trait("Category", "Intergration")]
        //public void Can_Get_Included_Fields()
        //{
        //    var lpNumber = "LP-02039";
        //    var landmarks = _dbContext.Landmarks.Where(x => x.LP_NUMBER == lpNumber).Select(x => x).ToList();

        //    var landmark = landmarks.First();
        //    Assert.Equal(lpNumber, landmark.LP_NUMBER);
        //}


       // [SkippableFact, Trait("Category", "Intergration")]
        public void Can_Get_Included_Pluto_Fields()
        {
            //var lpNumber = "LP-02039";
            //var landmarks = _dbContext.Landmarks.Where(x => x.LP_NUMBER == lpNumber).Select(x => x.Pluto).ToList();

            //var pluto = landmarks.First();
            //Assert.IsType<Pluto>(pluto);
        }


 [SkippableFact]
      //  [Fact, Trait("Category", "Intergration")]
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
                SortOrder = !string.IsNullOrEmpty(request.SortOrder) ? request.SortOrder : null
            };

            var sortingList = new List<SortModel>{sortModel};

            var results = _landmarkRepository
                .GetPage(predicate, request.PageSize * (request.Page - 1), request.PageSize, sortingList);

            Assert.NotNull(results);

        }
    }
}
