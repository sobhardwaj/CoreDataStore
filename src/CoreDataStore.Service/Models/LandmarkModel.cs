namespace CoreDataStore.Service.Models
{
    public class LandmarkModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LPNumber { get; set; }
   
        public long BBL { get; set; }

        public long BinNumber { get; set; }

        //public string BoroughID { get; set; }

        public string ObjectType { get; set; }

        public int Block { get; set; }

        public int Lot { get; set; }

        public string PlutoAddress { get; set; }

        public string DesignatedAddress { get; set; }





       // public string DESIG_DATE { get; set; }

        //public string CALEN_DATE { get; set; }

        //public string PUBLIC_HEA { get; set; }



        //public string HIST_DISTR { get; set; }

        //public string OTHER_HEAR { get; set; }

        //public string BOUNDARIES { get; set; }

        public bool IsCurrent { get; set; }

        public string Status { get; set; }


        //public string LAST_ACTIO { get; set; }

        //public string STATUS_NOT { get; set; }

        //public string COUNT_BLDG { get; set; }

        //public string NON_BLDG { get; set; }

        public bool IsVacantLot { get; set; }

        ////public string SECND_BLDG] );


    }
}
