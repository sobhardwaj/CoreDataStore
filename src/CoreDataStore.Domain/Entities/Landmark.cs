using System;
using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class Landmark : IEntityBase
    {
        public long Id { get; set; }

        public long BBL { get; set; }

        public long BIN_NUMBER { get; set; }

        public long? OBJECTID { get; set; }

        public string BoroughID { get; set; }

        /// <summary>
        ///  Block
        /// </summary>
        public int BLOCK { get; set; }

        /// <summary>
        /// Lot
        /// </summary>
        public int LOT { get; set; }

        /// <summary>
        /// LPC Number
        /// </summary>
        public string LP_NUMBER { get; set; }

        /// <summary>
        /// Landmark Name
        /// </summary>
        public string LM_NAME { get; set; }

        /// <summary>
        /// Pluto Address
        /// </summary>
        public string PLUTO_ADDR { get; set; }

        /// <summary>
        /// Designated Address
        /// </summary>
        public string DESIG_ADDR { get; set; }

        /// <summary>
        /// Designated Date.
        /// </summary>
        public DateTime? DESIG_DATE { get; set; }

        /// <summary>
        /// Calendared Date
        /// </summary>
        public DateTime? CALEN_DATE { get; set; }

        public string PUBLIC_HEA { get; set; }

        /// <summary>
        /// Landmark Type
        /// </summary>
        public string LM_TYPE { get; set; }

        /// <summary>
        /// Historic District
        /// </summary>
        public string HIST_DISTR { get; set; }

        public string OTHER_HEAR { get; set; }

        public string BOUNDARIES { get; set; }

        public bool MOST_CURRE { get; set; }

        public string STATUS { get; set; }

        /// <summary>
        /// Last Action
        /// </summary>
        public string LAST_ACTIO { get; set; }

        public string STATUS_NOT { get; set; }

        public bool COUNT_BLDG { get; set; }

        public string NON_BLDG { get; set; }

        /// <summary>
        /// Vacant Lot
        /// </summary>
        public bool VACANT_LOT { get; set; }

        public bool SECND_BLDG { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        public virtual LpcReport LPCReport { get; set; }
    }
}
