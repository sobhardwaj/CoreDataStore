using CoreDataStore.Domain.Entities.Base;

namespace CoreDataStore.Domain.Entities
{
    public class Landmark  : IEntityBase
    {
        public int Id { get; set; }

        public long BBL { get; set; }

        public long BIN_NUMBER { get; set; }

        public string BoroughID { get; set; }

        public int BLOCK { get; set; }

        public int LOT { get; set; }

        public string LP_NUMBER { get; set; }

        public string LM_NAME { get; set; }

        public string PLUTO_ADDR { get; set; }

        public string DESIG_ADDR { get; set; }

       // public string DESIG_DATE { get; set; }

       // public string CALEN_DATE { get; set; }

        public string PUBLIC_HEA { get; set; }

        public string LM_TYPE { get; set; }

        public string HIST_DISTR { get; set; }

        public string OTHER_HEAR { get; set; }

        public string BOUNDARIES { get; set; }

        public bool MOST_CURRE { get; set; } 
      
        public string STATUS { get; set; }

        public string LAST_ACTIO { get; set; }

        public string STATUS_NOT { get; set; }

        public bool COUNT_BLDG { get; set; }

        public string NON_BLDG { get; set; }

        public bool VACANT_LOT { get; set; }

        public bool SECND_BLDG { get; set; }
        
    }
}
