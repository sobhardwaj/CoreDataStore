using System.Collections.Generic;
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
        public void Get_Lpc_Pluto_Item_Returns_Data()
        {
            var dataSet = PlutoDataSource.GetPlutoModelList(20);

            var plutoService = new Mock<IPlutoService>();
            plutoService.Setup(x => x.GetPluto(It.IsAny<string>()))
                .Returns(dataSet);

            var controller = GetPlutoController(plutoService.Object);

            // Act
            var lpcId = System.Guid.NewGuid().ToString();
            var sut = controller.Get(lpcId);

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

        [Fact(DisplayName = "Pluto LPC Item - (Not Found)")]
        [Trait("Category", "Unit")]
        public void Get_Lpc_Pluto_Item_Returns_Not_Found()
        {
            var controller = GetPlutoController();

            var sut = controller.Get(null);

            // Assert
            Assert.NotNull(sut);
        }

        private PlutoController GetPlutoController(IPlutoService plutoService = null)
        {
            plutoService = plutoService ?? new Mock<IPlutoService>().Object;
            return new PlutoController(plutoService);
        }
    }
}
