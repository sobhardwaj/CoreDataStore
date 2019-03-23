using System.Threading.Tasks;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Services
{
    public class LpcReportServiceTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILpcReportService _lpcReportService;

        private readonly ITestOutputHelper _output;

        public LpcReportServiceTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lpcReportService = fixture.LPCReportService;
            _output = output;
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_Filtered_Paging_List()
        {
            var request = new LpcReportRequest
            {
                PageSize = 20,
                Page = 1,
                Borough = "Manhattan",
            };

            var results = _lpcReportService.GetLPCReports(request).Results;
            Assert.Equal(request.PageSize, results.Count);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Can_Get_LpcReport()
        {
            var sut = _lpcReportService.GetLPCReport(1);

            Assert.NotNull(sut);
            Assert.IsType<LpcReportModel>(sut);

            Assert.NotEmpty(sut.PhotoURL);
            Assert.NotEmpty(sut.PdfURL);
            Assert.NotEmpty(sut.MapURL);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Can_Get_LpcReport_Async()
        {
            var sut = await _lpcReportService.GetLPCReportAsync(1);

            Assert.NotNull(sut);
            Assert.IsType<LpcReportModel>(sut);

            Assert.NotEmpty(sut.PhotoURL);
            Assert.NotEmpty(sut.PdfURL);
            Assert.NotEmpty(sut.MapURL);
        }
    }
}
