using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class Pluto : IEntityBase
    {
        public long Id { get; set; }

        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

        /// <summary>
        /// Block
        /// </summary>
        public int Block { get; set; }

        /// <summary>
        /// Lot
        /// </summary>
        public int Lot { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Owner Name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Lot Area
        /// </summary>
        public int LotArea { get; set; }

        /// <summary>
        /// Number of Buildings
        /// </summary>
        public int NumBldgs { get; set; }

        /// <summary>
        /// Year Built
        /// </summary>
        public int YearBuilt { get; set; }

        /// <summary>
        /// Landmark Name
        /// </summary>
        public string LandmarkName { get; set; }

        /// <summary>
        /// Historic District
        /// </summary>
        public string HistDist { get; set; }

        public long BBL { get; set; }

        /// <summary>
        /// Zip Code
        /// </summary>
        public string ZipCode { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        /// <summary>
        /// Latitude 
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal Longitude { get; set; }
    }
}
