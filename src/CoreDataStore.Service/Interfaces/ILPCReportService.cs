using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    /// <summary>
    /// Lpc Report Service Interface
    /// </summary>
    public interface ILpcReportService
    {
        /// <summary>
        /// Get Lpc Report
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LpcReportModel</returns>
        LpcReportModel GetLPCReport(int id);

        /// <summary>
        ///  Get Lpc Report Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LpcReportModel> GetLPCReportAsync(int id);

        /// <summary>
        ///  Get All Lpc Reports
        /// </summary>
        /// <returns></returns>
        List<LpcReportModel> GetLPCReports();

        /// <summary>
        ///  Get All Lpc Reports Async
        /// </summary>
        Task<List<LpcReportModel>> GetLPCReportsAsync();

        LpcReportModel UpdateLPCReport(LpcReportModel model);

        PagedResultModel<LpcReportModel> GetLPCReports(LpcReportRequest request);
    }
}
