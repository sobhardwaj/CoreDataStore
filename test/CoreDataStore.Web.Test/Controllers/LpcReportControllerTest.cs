using System.Linq;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Test.Data;
using CoreDataStore.Web.Controllers;
using CoreDataStore.Web.Test.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreDataStore.Web.Test.Controllers
{
    public class LpcReportControllerTest
    {




        [Fact(DisplayName = "LPC Streets - (Returns Data)")]
        [Trait("Category", "Unit")]
        public void Get_Lpc_Streets_Returns_Data()
        {
            var dataSet = LpcReportDataSource.GetLpcReportsList(30).Select(x => x.Street).ToList();

            var landmarkService = new Mock<ILandmarkService>();
            landmarkService.Setup(x => x.GetLandmarkStreets(It.IsAny<string>()))
                .Returns(dataSet);

            var controller = GetLpcReportController(null, landmarkService.Object);
            controller.ControllerContext = WebTestHelpers.GetHttpContext();

            // Act
            var lpcId = System.Guid.NewGuid().ToString();
            var sut = controller.GetStreets(lpcId);

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<OkObjectResult>(sut);

            var objectResult = sut as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.True(objectResult.StatusCode == 200);
        }

        [Fact(DisplayName = "LPC Streets - (Not Found)")]
        [Trait("Category", "Unit")]
        public void Get_Lpc_Streets_Returns_Not_Found()
        {
            var controller = GetLpcReportController();

            var sut = controller.GetStreets(null);

            // Assert
            Assert.NotNull(sut);
        }

        private LpcReportController GetLpcReportController(ILPCReportService lpcReportService = null, ILandmarkService landmarkService = null)
        {
            lpcReportService = lpcReportService ?? new Mock<ILPCReportService>().Object;
            landmarkService = landmarkService ?? new Mock<ILandmarkService>().Object;

            return new LpcReportController(lpcReportService, landmarkService);
        }
    }
}
