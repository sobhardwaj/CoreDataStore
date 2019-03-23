using System.Collections.Generic;
using System.Threading.Tasks;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILandmarkService
    {
        List<string> GetLandmarkStreets(string lpcNumber);

        Task<List<string>> GetLandmarkStreetsAsync(string lpcNumber);

        PagedResultModel<LandmarkModel> GetLandmarks(LandmarkRequest request);
    }
}
