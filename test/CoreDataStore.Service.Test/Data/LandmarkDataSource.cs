using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Models;
using GenFu;

namespace CoreDataStore.Service.Test.Data
{
    public static class LandmarkDataSource
    {
        public static LandmarkModel GetLandMarkModelItem()
        {
            return GetLandMarkModelList(1).First();
        }

        public static List<LandmarkModel> GetLandMarkModelList(int count)
        {
            GenFu.GenFu.Configure<LpcReport>()
                .Fill(p => p.Name)
                .Fill(p => p.PhotoStatus, true)
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LandmarkModel>(100);
        }

    }
}
