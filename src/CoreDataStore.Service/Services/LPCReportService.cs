using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Service.Interfaces;

namespace CoreDataStore.Service.Services
{
    public class LPCReportService : ILPCReportService
    {
        private readonly ILPCReportRepository _lpcReportRepository;

        public LPCReportService(ILPCReportRepository lpcReportRepository)
        {
            this._lpcReportRepository = lpcReportRepository;
        }




    }
}
