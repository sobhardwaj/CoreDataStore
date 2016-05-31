using System.Collections.Generic;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreDataStore.Web.Controllers
{
    [Route("api/[controller]")]
    public class LPCReportController : Controller
    {
        private readonly ILPCReportRepository _lpcReportRepository;

        public LPCReportController(ILPCReportRepository lpcReportRepository)
        {
            _lpcReportRepository = lpcReportRepository;
        }

        [HttpGet]
        public IEnumerable<LPCReport> Get()
        {
            return _lpcReportRepository.GetAll();
        }



    }
}
