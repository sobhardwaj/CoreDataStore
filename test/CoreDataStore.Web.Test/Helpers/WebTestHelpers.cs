using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoreDataStore.Web.Test.Helpers
{
    public static class WebTestHelpers
    {
        public static ControllerContext GetHttpContext()
        {
            var response = new Mock<HttpResponse>();
            response.Setup(x => x.Headers).Returns(new Mock<IHeaderDictionary>().Object);

            var contextMock = new Mock<HttpContext>();
            contextMock.SetupGet(x => x.Response).Returns(response.Object);

            var controllerContextMock = new Mock<ControllerContext>();
            var controllerContext = controllerContextMock.Object;
            controllerContext.HttpContext = contextMock.Object;

            return controllerContext;
        }

        public static string GetWebApplicationPath()
        {
            string appPath = Directory.GetCurrentDirectory();
            string webPath = @"../../../../../src/CoreDataStore.Web";
            return Path.GetFullPath(Path.Combine(appPath, webPath));
        }
    }
}
