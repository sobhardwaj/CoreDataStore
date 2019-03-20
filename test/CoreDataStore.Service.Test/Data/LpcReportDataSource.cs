using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Domain.Entities;
using GenFu;

namespace CoreDataStore.Service.Test.Data
{
    public class LpcReportDataSource
    {
        public static LPCReport GetLpcReportItem()
        {
            return GetLpcReportsList(1).First();
        }

        public static List<LPCReport> GetLpcReportsList(int count)
        {
            GenFu.GenFu.Configure<LPCReport>()
                .Fill(p => p.Name)
                .Fill(p => p.Street).AsAddress()
                .Fill(p => p.PhotoURL);

            return GenFu.GenFu.ListOf<LPCReport>(100);
        }
    }
}
