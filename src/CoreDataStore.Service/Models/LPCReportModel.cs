using System;

namespace CoreDataStore.Service.Models
{
    public class LPCReportModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LPCId { get; set; }

        public string LPNumber { get; set; }

        public string ObjectType { get; set; }

        public string Architect { get; set; }

        public string Style { get; set; }

        public string Street { get; set; }

        public string Borough { get; set; }

        public DateTime DateDesignated { get; set; }

        public double Latitude => 40.7828647 + (this.Id * .0001);

        public double Longitude => -73.9653551 + (this.Id * .0001);

        public bool PhotoStatus { get; set; }

        public string PhotoURL { get; set; }

  

    }
}
