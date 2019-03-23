using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Service.Models;
using GenFu;
using Navigator.Common.Helpers;

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
            var boroughCodes = EnumHelper.EnumToList<Borough>().Select(e => e.GetAttribute<BoroughIdAttribute>().Value);

            GenFu.GenFu.Configure<LandmarkModel>()
                .Fill(p => p.Name)
                .Fill(p => p.BoroughId, () => BaseValueGenerator.GetRandomValue(boroughCodes))
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LandmarkModel>(count);
        }
    }
}
