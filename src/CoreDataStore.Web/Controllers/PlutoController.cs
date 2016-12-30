using System.Collections.Generic;
using CoreDataStore.Service.Interfaces;
using CoreDataStore.Service.Models;
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces(typeof(IEnumerable<PlutoModel>))]
        [ProducesResponseType(typeof(IEnumerable<PlutoModel>), 200)]
        [HttpGet("{lpcNumber}")]
        public IEnumerable<PlutoModel> Get(string lpcNumber)
        {
            return _plutoService.GetPluto(lpcNumber);
        }

    }
}
