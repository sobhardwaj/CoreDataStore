using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using GenFu;

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
            GenFu.GenFu.Configure<LpcReport>()
                .Fill(p => p.Name)
                .Fill(p => p.PhotoStatus, true)
                .Fill(p => p.Street).AsAddress();

            return GenFu.GenFu.ListOf<LpcReport>(100);
        }
    }
}
