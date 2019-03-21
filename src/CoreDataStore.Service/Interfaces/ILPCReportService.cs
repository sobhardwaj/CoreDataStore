using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILpcReportService
    {
        LpcReportModel GetLPCReport(int id);

        List<LpcReportModel> GetLPCReports();

        LpcReportModel UpdateLPCReport(LpcReportModel model);

        PagedResultModel<LpcReportModel> GetLPCReports(LpcReportRequest request);
    }
}
