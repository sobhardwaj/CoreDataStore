using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILPCReportService
    {
        LPCReportModel GetLPCReport(int id);

        List<LPCReportModel> GetLPCReports();

        List<LPCReportModel>  GetLPCReports(LPCReportRequest request, out int totalCount);
    }
}