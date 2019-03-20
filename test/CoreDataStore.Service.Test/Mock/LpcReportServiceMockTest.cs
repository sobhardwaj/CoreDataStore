using System.Collections.Generic;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Service.Mappings;
using CoreDataStore.Service.Models;
using CoreDataStore.Service.Services;
using CoreDataStore.Service.Test.Data;
using Moq;
using Xunit;

namespace CoreDataStore.Service.Test.Mock
{
    public class LpcReportServiceMockTest
    {


        [Fact(DisplayName = "Get LPC Report Item List")]
        [Trait("Category", "Unit")]
        public void Get_LPC_Report_List_Item_Data()
        {
            var dataSet = LpcReportDataSource.GetLpcReportsList(20);

            var lpcRepository = new Mock<ILpcReportRepository>();
            lpcRepository.Setup(b => b.GetAll())
                .Returns(dataSet);

            var lpcReportService = GetLpcReportService(lpcRepository.Object);

            // Act
            var sut = lpcReportService.GetLPCReports();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<List<LPCReportModel>>(sut);
        }


        private LpcReportService GetLpcReportService(ILpcReportRepository lpcReportRepository = null)
        {
            AutoMapperConfiguration.Configure();

            lpcReportRepository = lpcReportRepository ?? new Mock<ILpcReportRepository>().Object;
            return new LpcReportService(lpcReportRepository);
        }
    }
}
