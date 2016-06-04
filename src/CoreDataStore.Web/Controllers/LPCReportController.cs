using System.Collections.Generic;
using CoreDataStore.Data.Sqlite.Filters;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Interfaces;
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
        private readonly ILPCReportService _lpcReportService;

        public LPCReportController(ILPCReportService lpcReportService)
        {
            _lpcReportService = lpcReportService;
        }


        // [HttpGet("{limit:int}/{page:int}")]


        /// <summary>
        /// Get Filtered Results
        /// </summary>
        /// <param name="query">Query String Parms</param>
        /// <param name="limit">Records per Page</param>
        /// <param name="page">Page Number</param>
        /// <returns></returns>
        // [HttpGet]
        // [Route("{limit:int}/{page:int}")]

        [HttpGet("{limit:int}/{page:int}")]
        [Produces(typeof(IEnumerable<LPCReport>))]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<LPCReport>))]
        public IEnumerable<LPCReport> Get([FromQuery]LPCReportRequestModel query, int limit, int page)
        {
            var totalRecords = 0;
            var request = new LPCReportRequest
             {
                PageSize = limit,
                Page = page,
                SortColumn = !string.IsNullOrEmpty(query.Sort) ? query.Sort : "name",
                SortOrder = !string.IsNullOrEmpty(query.Order) ? query.Order : "asc",
                Borough = query.Borough,
                ObjectType = query.ObjectType
            };

            var results = _lpcReportService.GetLPCReports(request,out totalRecords);
            HttpContext.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return results;
        }

    }
}
