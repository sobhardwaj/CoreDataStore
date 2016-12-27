using System.Collections.Generic;
using CoreDataStore.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoreDataStore.Web.Controllers
{
    /// <summary>
    /// PLUTO Controller
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class PlutoController : Controller
    {
        private readonly IPlutoService _plutoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plutoService"></param>
        public PlutoController(IPlutoService plutoService)
        {
            this._plutoService = plutoService;
        }


        // GET: api/values
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
