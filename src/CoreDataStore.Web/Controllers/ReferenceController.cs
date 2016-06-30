using System.Collections.Generic;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Cors;

namespace CoreDataStore.Web.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class ReferenceController : Controller
    {
        private readonly IReferenceRepository _referenceRepository;

        public ReferenceController(IReferenceRepository referenceRepository)
        {
            this._referenceRepository = referenceRepository;
        }

        [HttpGet]
        [Route("borough")]
        public IEnumerable<string> GetBoroughs()
        {
            return new string[] { "Brooklyn", "Bronx", "Mahhattan", "Queens", "Staten Island" }; 
        }

        [HttpGet]
        [Route("objectType")]
        public IEnumerable<string> GetReferenceTypes()
        {
            return new string[] { "Individual Landmark", "Historic District", "Scenic Landmark", "Interior Landmark" };
        }

  
        /////// <summary>
        ///////  Reference Types List
        /////// </summary>
        /////// <returns></returns>
        //// [Route("objectType")]
        //// [Produces(typeof(List<KeyValuePair<string, string>>))]
        /// 
        //[HttpGet]
        //public IEnumerable<ReferenceType> GetReferenceTypes()
        //{
        //    var results = _referenceRepository.GetObjectTypes();
        //    return results;
        //}


    }
}
