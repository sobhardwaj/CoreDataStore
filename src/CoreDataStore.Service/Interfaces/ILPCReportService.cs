using System.Collections.Generic;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILPCReportService
    {
        List<LPCReportModel> GetLPCReports();

        List<LPCReportModel> GetLPCReports(LPCReportRequest request, out int totalCount);
    }
}