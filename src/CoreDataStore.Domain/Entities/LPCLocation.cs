using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class LpcLocation : IEntityBase, IAuditableEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// LPC Number
        /// </summary>
        public string LPNumber { get; set; }

        /// <summary>
        ///  Landmark Name
        /// </summary>
        public string Name { get; set; }

        public long? BBL { get; set; }

        public long? BIN { get; set; }

        public long? ObjectId { get; set; }

        public string ObjectType { get; set; }

        public string LocationType { get; set; }

        /// <summary>
        /// Street 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Neighborhood
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

        /// <summary>
        /// Zip Code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Block
        /// </summary>
        public int? Block { get; set; }

        /// <summary>
        /// Lot
        /// </summary>
        public int? Lot { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        public LpcReport LPCReport { get; set; }
    }
}
