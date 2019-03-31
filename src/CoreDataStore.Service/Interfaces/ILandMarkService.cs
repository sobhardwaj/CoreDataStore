using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    /// <summary>
    /// Landmark Service interface
    /// </summary>
    public interface ILandmarkService
    {
        /// <summary>
        ///  Get Landmark Streets for Lpc Report.
        /// </summary>
        /// <param name="lpcNumber">LPC Id</param>
        /// <returns></returns>
        List<string> GetLandmarkStreets(string lpcNumber);

        /// <summary>
        ///  Get Landmark Streets for Lpc Report Async.
        /// </summary>
        /// <param name="lpcNumber">LPC Id</param>
        /// <returns></returns>
        Task<List<string>> GetLandmarkStreetsAsync(string lpcNumber);

        PagedResultModel<LandmarkModel> GetLandmarks(LandmarkRequest request);
    }
}
