using System.Collections.Generic;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CoreDataStore.Data.Data;
using CoreDataStore.Web.ViewModels;
using Navigator.Common.Helpers;

namespace CoreDataStore.Web.Controllers
{
    /// <summary>
    /// Location Controller
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class LocationController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        public LocationController()
        {

        }

        /// <summary>
        /// Validates User Postion is in Range
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Location/validate/")]
        public IActionResult Validate([FromBody] Position position)
        {
            return Ok(false);
        }


        /// <summary>
        ///  Get User Location
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Position), 200)]
        [Produces("application/json")]
        public IActionResult Post([FromBody]Position position)
        {
            var location = position;
            return Ok(location);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }

    }

}
