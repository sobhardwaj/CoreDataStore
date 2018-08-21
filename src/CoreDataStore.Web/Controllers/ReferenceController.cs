using System.Collections.Generic;
using System.Linq;
using CoreDataStore.Data.Data;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Navigator.Common.Helpers;

namespace CoreDataStore.Web.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class ReferenceController : Controller
    {
        private readonly IReferenceRepository _referenceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceController"/> class.
        /// </summary>
        /// <param name="referenceRepository"></param>
        public ReferenceController(IReferenceRepository referenceRepository)
        {
            this._referenceRepository = referenceRepository;
        }

        /// <summary>
        ///  Get Boroughs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("borough")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [Produces("application/json", Type = typeof(IEnumerable<string>))]
        public IEnumerable<string> GetBoroughs()
        {
            return EnumHelper.EnumToList<Borough>().Select(e => e.GetDescription());
        }

        /// <summary>
        ///  Get Reference Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("objectType")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [Produces("application/json", Type = typeof(IEnumerable<string>))]
        public IEnumerable<string> GetReferenceTypes()
        {
            return EnumHelper.EnumToList<ObjectType>().Select(e => e.GetDescription());
        }

        /// <summary>
        ///  Get Parent Styles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("parentStyle")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [Produces("application/json", Type = typeof(IEnumerable<string>))]
        public IEnumerable<string> GetParentStyles()
        {
            return StylesData.GetParentStyles();
        }
    }
}
