using System.Collections.Generic;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            return EnumHelper.EnumToList<Borough>().Select(e => e.GetDescription());
        }

        [HttpGet]
        [Route("objectType")]
        public IEnumerable<string> GetReferenceTypes()
        {
            return new string[] { "Individual Landmark", "Historic District", "Scenic Landmark", "Interior Landmark" };
        }


    }
}
