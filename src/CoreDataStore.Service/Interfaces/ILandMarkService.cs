using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Models;

namespace CoreDataStore.Service.Interfaces
{
    public interface ILandmarkService
    {
        List<string> GetLandmarkStreets(string lpcNumber);

        PagedResultModel<LandmarkModel> GetLandmarks(LandmarkRequest request);
    }
}