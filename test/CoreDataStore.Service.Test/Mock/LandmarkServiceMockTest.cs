using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Services;
using CoreDataStore.Service.Test.Data;
using Moq;
using Navigator.Common.Helpers;
using Xunit;

namespace CoreDataStore.Service.Test.Mock
{
    public class LandmarkServiceMockTest
    {
        [Fact(DisplayName = "Get Landmark Street List")]
        [Trait("Category", "Unit")]
        public async Task Get_Landmark_Item_Street_List()
        {
            var dataSet = LandmarkDataSource.GetLandmarkList(20);
            var predicate = PredicateBuilder.True<Landmark>();

            var repository = new Mock<ILandmarkRepository>();
            repository.Setup(b => b.FindByAsync(predicate))
                .ReturnsAsync(dataSet);

            var service = GetLandmarkService(repository.Object);

            // Act
            string id = Guid.NewGuid().ToString();
            var sut = await service.GetLandmarkStreetsAsync(id);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<List<string>>(sut);
        }

        private LandmarkService GetLandmarkService(ILandmarkRepository landmarkRepository = null)
        {
            AutoMapperConfiguration.Configure();

            landmarkRepository = landmarkRepository ?? new Mock<ILandmarkRepository>().Object;
            return new LandmarkService(landmarkRepository);
        }
    }
}
