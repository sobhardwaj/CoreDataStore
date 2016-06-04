using System.Collections.Generic;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILPCReportService
    {
        List<LPCReport> GetLPCReports();

        List<LPCReport> GetLPCReports(LPCReportRequest request, out int totalCount);
    }
}