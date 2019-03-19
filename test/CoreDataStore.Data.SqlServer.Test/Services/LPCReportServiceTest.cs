using CoreDataStore.Data.Filters;
using CoreDataStore.Data.SqlServer.Test.Fixtures;
using CoreDataStore.Service.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace CoreDataStore.Data.SqlServer.Test.Services
{
    public class LpcReportServiceTest : IClassFixture<CoreDataStoreDbFixture>
    {
        private readonly ILPCReportService _lpcReportService;

        private readonly ITestOutputHelper _output;

        public LpcReportServiceTest(CoreDataStoreDbFixture fixture, ITestOutputHelper output)
        {
            _lpcReportService = fixture.LPCReportService;
            _output = output;
        }

        [Fact(Skip = "TODO")]
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
    }
}
