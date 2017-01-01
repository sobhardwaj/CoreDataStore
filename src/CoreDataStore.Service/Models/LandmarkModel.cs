using System;

namespace CoreDataStore.Service.Models
{
    public class LandmarkModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LPNumber { get; set; }
   
        public long BBL { get; set; }

        public long BinNumber { get; set; }

        public string BoroughId { get; set; }

        public string ObjectType { get; set; }

        public int Block { get; set; }

        public int Lot { get; set; }

        public string PlutoAddress { get; set; }

        public string DesignatedAddress { get; set; }

        public DateTime? DesignatedDate { get; set; }

        public DateTime? CalendaredDate { get; set; }

        public string PublicHearingDate { get; set; }

        public string HistoricDistrict { get; set; }

        public string OtherHearingDate { get; set; }

        public string Boundries { get; set; }

        public bool IsCurrent { get; set; }

        public string Status { get; set; }

        public string LastAction { get; set; }

        public string PriorStatus { get; set; }

        public string RecordType { get; set; }

        public bool IsBuilding { get; set; }

        public bool IsVacantLot { get; set; }

        public bool IsSecondaryBuilding { get; set; }

        public LPCReportModel LPCReport { get; set; }

    }
}
