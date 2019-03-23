using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;
using CoreDataStore.Service.Test.Data;
using CoreDataStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreDataStore.Web.Test.Controllers
{
    public class PlutoControllerTest
    {
        [Fact(DisplayName = "Pluto LPC Item (Data)")]
        [Trait("Category", "Unit")]
        public async Task Get_Lpc_Pluto_Item_Returns_Data()
        {
            var dataSet = PlutoDataSource.GetPlutoModelList(20);

            var plutoService = new Mock<IPlutoService>();
            plutoService.Setup(x => x.GetPlutoAsync(It.IsAny<string>()))
                .ReturnsAsync(dataSet);

            var controller = GetPlutoController(plutoService.Object);

            // Act
            var lpcId = System.Guid.NewGuid().ToString();
            var sut = await controller.Get(lpcId);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<OkObjectResult>(sut);

            var objectResult = sut as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.True(objectResult.StatusCode == 200);
            Assert.IsType<List<PlutoModel>>(objectResult.Value);

            var result = objectResult.Value as List<PlutoModel>;
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Pluto LPC Item - (Bad Request)")]
        [Trait("Category", "Unit")]
        public async Task Get_Lpc_Pluto_Item_Returns_Bad_Request()
        {
            var controller = GetPlutoController();

            var sut = await controller.Get(null);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<BadRequestResult>(sut);
        }

        [Fact(DisplayName = "Pluto LPC Item - (Not Found)")]
        [Trait("Category", "Unit")]
        public async Task Get_Lpc_Pluto_Item_Returns_Not_Found()
        {
            var plutoService = new Mock<IPlutoService>();
            plutoService.Setup(x => x.GetPlutoAsync(It.IsAny<string>()))
                .ReturnsAsync((List<PlutoModel>)null);

            var controller = GetPlutoController(plutoService.Object);

            // Act
            var id = Guid.NewGuid().ToString();
            var sut = await controller.Get(id);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<NotFoundResult>(sut);
        }

        private PlutoController GetPlutoController(IPlutoService plutoService = null)
        {
            plutoService = plutoService ?? new Mock<IPlutoService>().Object;
            return new PlutoController(plutoService);
        }
    }
}
