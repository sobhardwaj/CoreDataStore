using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILpcReportService
    {
        LpcReportModel GetLPCReport(int id);

        Task<LpcReportModel> GetLPCReportAsync(int id);

        List<LpcReportModel> GetLPCReports();

        Task<List<LpcReportModel>> GetLPCReportsAsync();

        LpcReportModel UpdateLPCReport(LpcReportModel model);

        PagedResultModel<LpcReportModel> GetLPCReports(LpcReportRequest request);
    }
}
