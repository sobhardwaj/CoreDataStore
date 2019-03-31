using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class LpcLamppost : IEntityBase, IAuditableEntity
    {
        public long Id { get; set; }

        public int PostId { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }

        /// <summary>
        /// Block
        /// </summary>
        public int? Block { get; set; }

        /// <summary>
        /// Lot
        /// </summary>
        public int? Lot { get; set; }

        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

        public string Located { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

    }


}
