using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILPCReportService
    {
        LPCReportModel GetLPCReport(int id);

        List<LPCReportModel> GetLPCReports();

        List<string> GetAddresses(string lpcNumber);

        LPCReportModel UpdateLPCReport(LPCReportModel model);

        PagedResultModel<LPCReportModel> GetLPCReports(LPCReportRequest request);
    }
}