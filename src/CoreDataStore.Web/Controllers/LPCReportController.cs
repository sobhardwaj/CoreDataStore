using System;
using System.Collections.Generic;
using CoreDataStore.Data.Filters;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;
using CoreDataStore.Service.ValidationRules;
using CoreDataStore.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace CoreDataStore.Web.Controllers
{

    /// <summary>
    /// LPC Reports API Controllers.
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class LPCReportController : Controller
    {
        private readonly ILPCReportService _lpcReportService;
        private readonly ILandmarkService _landmarkService;

        public LPCReportController(ILPCReportService lpcReportService, ILandmarkService landmarkService)
        {
            _lpcReportService = lpcReportService;
            _landmarkService = landmarkService;
        }


        /// <summary>
        /// Get LPC Report
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [Produces(typeof(LPCReportModel))]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(LPCReportModel))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lpcReportService.GetLPCReport(id);
            if (result == null)
                return BadRequest();

            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]LPCReportModel model)
        {
            var validator = new LPCReportRule();
            var validationResults = validator.Validate(model);

            if (!validationResults.IsValid)
                return Json(validationResults.Errors);

            var result = _lpcReportService.GetLPCReport(id);
            if (result == null)
                return NotFound();

            //TODO Add Update Logic

            return new NoContentResult();
        }


        /// <summary>
        /// Get LPC Reports Filtered Results
        /// </summary>
        /// <param name="query">Query String Parms</param>
        /// <param name="limit">Records per Page</param>
        /// <param name="page">Page Number</param>
        /// <returns></returns>
        [Produces(typeof(PagedResultModel<LPCReportModel>))]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(PagedResultModel<LPCReportModel>))]
        [HttpGet("{limit:int}/{page:int}")]
        public IEnumerable<LPCReportModel> Get([FromQuery]LPCReportRequestModel query, int limit, int page)
        {
            long totalRecords = 0;
            var request = new LPCReportRequest
             {
                PageSize = limit,
                Page = page,
                SortColumn = !string.IsNullOrEmpty(query.Sort) ? query.Sort : "name",
                SortOrder = !string.IsNullOrEmpty(query.Order) ? query.Order : "asc",
                ParentStyleList = !string.IsNullOrEmpty(query.ParentStyles) ? query.ParentStyles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList() : null,
                Borough = query.Borough,
                ObjectType = query.ObjectType
            };

            var records = _lpcReportService.GetLPCReports(request);
            totalRecords = records.Total;
            HttpContext.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return records.Results;
        }


        /// <summary>
        /// Get Landmark Filtered Results
        /// </summary>
        /// <param name="query">Query String Parms</param>
        /// <param name="limit">Records per Page</param>
        /// <param name="page">Page Number</param>
        /// <returns></returns>
        [Produces(typeof(PagedResultModel<LandmarkModel>))]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(PagedResultModel<LandmarkModel>))]
        [HttpGet("landmark/{limit:int}/{page:int}")]
        public IEnumerable<LandmarkModel> GetLandmarks([FromQuery]LandmarkRequestModel query, int limit, int page)
        {
            long totalRecords = 0;
            var request = new LandmarkRequest
            {
                PageSize = limit,
                Page = page,
                SortColumn = !string.IsNullOrEmpty(query.Sort) ? query.Sort : "LP_NUMBER",
                SortOrder = !string.IsNullOrEmpty(query.Order) ? query.Order : "asc",
                LPCNumber = query.LPCNumber,
            };

            var records = _landmarkService.GetLandmarks(request);
            totalRecords = records.Total;
            HttpContext.Response.Headers.Add("X-InlineCount", totalRecords.ToString());
            return records.Results;
        }

    }
}
