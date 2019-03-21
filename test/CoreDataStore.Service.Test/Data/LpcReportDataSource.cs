using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Service.Models;
using GenFu;
using Navigator.Common.Helpers;

namespace CoreDataStore.Service.Test.Data
{
    public static class LpcReportDataSource
    {
        public static LpcReport GetLpcReportItem()
        {
            return GetLpcReportsList(1).First();
        }

        public static List<LpcReport> GetLpcReportsList(int count)
        {
            var boroughs = EnumHelper.EnumToList<Borough>().Select(e => e.GetDescription());
            var boroughCodes = EnumHelper.EnumToList<Borough>().Select(e => e.GetAttribute<BoroughIdAttribute>().Value);
            var objectTypes = EnumHelper.EnumToList<ObjectType>().Select(e => e.GetDescription());

            var i = 0;
            GenFu.GenFu.Configure<LpcReport>()
                .Fill(l => l.Id, () => ++i)
                .Fill(l => l.LPNumber, () => $"LP-{i,5:D5}")
                .Fill(l => l.LPCId, () => $"{i,5:D5}")
                .Fill(p => p.Name)
                .Fill(l => l.Borough, () => BaseValueGenerator.GetRandomValue(boroughs))
                .Fill(l => l.ObjectType, () => BaseValueGenerator.GetRandomValue(objectTypes))
                .Fill(p => p.PhotoStatus, true)
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LpcReport>(100);
        }

        public static List<LpcReportModel> GetLpcReportModelList(int count)
        {
            GenFu.GenFu.Configure<LpcReport>()
                .Fill(p => p.Name)
                .Fill(p => p.PhotoStatus, true)
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LpcReportModel>(100);
        }
    }
}
