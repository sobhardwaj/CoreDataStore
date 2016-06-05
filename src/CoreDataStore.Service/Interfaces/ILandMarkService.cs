using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILandmarkService
    {
        List<LandmarkModel> GetLandmarks(LandmarkRequest request, out int totalCount);
    }
}