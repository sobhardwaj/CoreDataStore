using CoreDataStore.Data.Sqlite.Filters.Base;

namespace CoreDataStore.Data.Filters
{
    public class PlutoRequest : RequestBase
    {
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
        /// BBL
        /// </summary>
        public int BBL { get; set; }

    }
}
