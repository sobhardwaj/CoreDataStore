using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Service.Models;
using GenFu;
using Navigator.Common.Helpers;

namespace CoreDataStore.Service.Test.Data
{
    public static class LandmarkDataSource
    {
        public static LandmarkModel GetLandmarkModelItem()
        {
            return GetLandmarkModelList(1).First();
        }

        public static List<LandmarkModel> GetLandmarkModelList(int count)
        {
            var boroughCodes = EnumHelper.EnumToList<Borough>().Select(e => e.GetAttribute<BoroughIdAttribute>().Value);

            GenFu.GenFu.Configure<LandmarkModel>()
                .Fill(p => p.Name)
                .Fill(p => p.BoroughId, () => BaseValueGenerator.GetRandomValue(boroughCodes))
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LandmarkModel>(count);
        }

        public static List<Landmark> GetLandmarkList(int count)
        {
            var boroughCodes = EnumHelper.EnumToList<Borough>().Select(e => e.GetAttribute<BoroughIdAttribute>().Value);

            GenFu.GenFu.Configure<Landmark>()
                .Fill(p => p.LM_NAME)
                .Fill(p => p.BoroughID, () => BaseValueGenerator.GetRandomValue(boroughCodes))
                .Fill(p => p.DESIG_ADDR).AsAddress()
                .Fill(p => p.PLUTO_ADDR).AsAddress();

            return GenFu.GenFu.ListOf<Landmark>(count);
        }
    }
}
