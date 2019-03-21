using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreDataStore.Web.Test.Controllers
{
    public class ReferenceControllerTest
    {
        [Fact(DisplayName = "Boroughs (Data)")]
        [Trait("Category", "Unit")]
        public void Get_Boroughs_Returns_Data()
        {
            var controller = GetReferenceController();

            // Act
            var sut = controller.GetBoroughs();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<OkObjectResult>(sut);

            var objectResult = sut as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.True(objectResult.StatusCode == 200);
        }

        [Fact(DisplayName = "Reference Types (Data)")]
        [Trait("Category", "Unit")]
        public void Get_Reference_Types_Returns_Data()
        {
            var controller = GetReferenceController();

            // Act
            var sut = controller.GetReferenceTypes();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<OkObjectResult>(sut);

            var objectResult = sut as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.True(objectResult.StatusCode == 200);
        }

        [Fact(DisplayName = "Parent Styles (Data)")]
        [Trait("Category", "Unit")]
        public void Get_Parent_Styles_Returns_Data()
        {
            var controller = GetReferenceController();

            // Act
            var sut = controller.GetParentStyles();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<OkObjectResult>(sut);

            var objectResult = sut as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.True(objectResult.StatusCode == 200);
        }

        private ReferenceController GetReferenceController(IReferenceRepository referenceRepository = null)
        {
            referenceRepository = referenceRepository ?? new Mock<IReferenceRepository>().Object;
            return new ReferenceController(referenceRepository);
        }
    }
}
