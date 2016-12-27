using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class Pluto : IEntityBase
    {
        public int Id { get; set; }

        public string Borough { get; set; }

        public int Block { get; set; }

        public int Lot { get; set; }

        public string OwnerName { get; set; }

        public int LotArea { get; set; }

        public int NumBldgs { get; set; }

        public int YearBuilt { get; set; }

        public string HistDist { get; set; }

        public int BBL { get; set; }

        public double XCoord { get; set; }

        public double YCoord { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
