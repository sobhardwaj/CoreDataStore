using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Interfaces;
using CoreDataStore.Domain.Entities;
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
            Assert.IsType<List<LpcReportModel>>(sut);

            var item = sut.First(x => x.PhotoStatus);
            Assert.NotNull(item);
            Assert.IsType<LpcReportModel>(item);

            Assert.NotEmpty(item.PhotoURL);
            Assert.NotEmpty(item.PdfURL);
            Assert.NotEmpty(item.MapURL);
        }

        [Fact(DisplayName = "Get LPC Report Item List")]
        [Trait("Category", "Unit")]
        public void Get_LPC_Report_List_Paging_Data()
        {
            int pageSize = 20;
            var dataSet = LpcReportDataSource.GetLpcReportsList(pageSize).AsQueryable();

            var lpcRepository = new Mock<ILpcReportRepository>();
            lpcRepository.Setup(b => b.GetCount(It.IsAny<Expression<Func<LpcReport, bool>>>()))
                .Returns(pageSize);

            lpcRepository.Setup(b => b.GetPage(It.IsAny<Expression<Func<LpcReport, bool>>>(), 1, 1, null))
                .Returns(dataSet);

            var lpcReportService = GetLpcReportService(lpcRepository.Object);

            // Act
            var request = new LpcReportRequest { PageSize = pageSize, Page = 1 };
            var sut = lpcReportService.GetLPCReports(request);

            // Assert
            Assert.NotNull(sut);
            Assert.IsAssignableFrom<PagedResultModel<LpcReportModel>>(sut);
        }

        private LpcReportService GetLpcReportService(ILpcReportRepository lpcReportRepository = null)
        {
            AutoMapperConfiguration.Configure();

            lpcReportRepository = lpcReportRepository ?? new Mock<ILpcReportRepository>().Object;
            return new LpcReportService(lpcReportRepository);
        }
    }
}
