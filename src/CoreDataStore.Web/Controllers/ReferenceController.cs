﻿using System.Collections.Generic;
using CoreDataStore.Common.Helpers;
using CoreDataStore.Domain.Enum;
using CoreDataStore.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CoreDataStore.Data.Data;

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
        /// 
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
        public IEnumerable<string> GetParentStyles()
        {
            return StylesData.GetParentStyles();
        }

    }
}
