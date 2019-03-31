using System;
using CoreDataStore.Domain.Entities.Base;
using System.Collections.Generic;

namespace CoreDataStore.Domain.Entities
{
    public class LpcReport : IEntityBase, IAuditableEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// Landmark Name
        /// </summary>
        public string Name { get; set; }

        public string LPCId { get; set; }

        /// <summary>
        /// LPC Number
        /// </summary>
        public string LPNumber { get; set; }

        /// <summary>
        /// Object Type
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Architect
        /// </summary>
        public string Architect { get; set; }

        /// <summary>
        /// Architectural Style
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

        /// <summary>
        /// Date Designated
        /// </summary>
        public DateTime DateDesignated { get; set; }

        /// <summary>
        /// Photo Status Exists
        /// </summary>
        public bool PhotoStatus { get; set; }

        /// <summary>
        /// Photo Url
        /// </summary>
        public virtual string PhotoURL { get; set; }

        public LpcLocation LPCLocation { get; set; }

        public List<Landmark> Landmarks { get; set; }

    }
}
