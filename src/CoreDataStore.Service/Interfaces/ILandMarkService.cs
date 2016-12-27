using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILandmarkService
    {
        PagedResultModel<LandmarkModel> GetLandmarks(LandmarkRequest request);
    }
}