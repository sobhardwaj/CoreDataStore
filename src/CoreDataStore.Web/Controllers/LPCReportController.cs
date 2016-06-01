using System.Collections.Generic;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Interfaces;
using CoreDataStore.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace CoreDataStore.Web.Controllers
{

    /// <summary>
    /// LPC Reports API Controllers.
    /// </summary>
    [Route("api/[controller]")]
    public class LPCReportController : Controller
    {
        private readonly ILPCReportRepository _lpcReportRepository;

        public LPCReportController(ILPCReportRepository lpcReportRepository)
        {
            _lpcReportRepository = lpcReportRepository;
        }


        /// <summary>
        /// Get Filtered Results
        /// </summary>
        /// <param name="query">Query String Parms</param>
        /// <param name="limit">Records per Page</param>
        /// <param name="page">Page Number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{limit:int}/{page:int}")]
        [Produces(typeof(IEnumerable<LPCReport>))]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<LPCReport>))]
        public IEnumerable<LPCReport> Get(LPCReportRequestModel query, int limit, int page)
        {
            return _lpcReportRepository.GetAll();
        }









    }
}
