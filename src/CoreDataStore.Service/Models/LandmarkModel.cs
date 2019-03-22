using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CoreDataStore.Service.Models
{
    public class LandmarkModel
    {
        public string Id { get; set; }

        /// <summary>
        ///  Landmark Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  LP Number
        /// </summary>
        public string LPNumber { get; set; }

        /// <summary>
        /// BBL
        /// </summary>
        public string BBL { get; set; }

        /// <summary>
        ///  Bin Number
        /// </summary>
        public long BinNumber { get; set; }

        /// <summary>
        ///  Object Id
        /// </summary>
        public long ObjectId { get; set; }

        /// <summary>
        /// Borough Id
        /// </summary>
        public string BoroughId { get; set; }

        /// <summary>
        ///  Object Type
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Block
        /// </summary>
        public int Block { get; set; }

        /// <summary>
        ///  Lot
        /// </summary>
        public int Lot { get; set; }

        /// <summary>
        /// Pluto Address
        /// </summary>
        public string PlutoAddress { get; set; }

        /// <summary>
        ///  Designated Address
        /// </summary>
        public string DesignatedAddress { get; set; }

        /// <summary>
        ///  Street Number
        /// </summary>
        public string Number
        {
            get
            {
                var number = !string.IsNullOrWhiteSpace(this.PlutoAddress) && this.PlutoAddress.Any(char.IsDigit)
                    ? this.PlutoAddress.Split(' ')[0].Trim()
                    : null;

                return number;
            }
        }

        /// <summary>
        /// Street
        /// </summary>
        public string Street
        {
            get
            {
                var street = !string.IsNullOrWhiteSpace(this.PlutoAddress) && this.PlutoAddress.Any(char.IsDigit)
                    ? Regex.Replace(this.PlutoAddress.Trim(), @"^[\d-]*\s*", string.Empty, RegexOptions.Multiline)
                    : this.PlutoAddress;

                return street;
            }
        }

        /// <summary>
        ///  Designated Date
        /// </summary>
        public DateTime? DesignatedDate { get; set; }

        /// <summary>
        /// Calendared Date
        /// </summary>
        public DateTime? CalendaredDate { get; set; }

        /// <summary>
        /// Public Hearing Date
        /// </summary>
        public string PublicHearingDate { get; set; }

        /// <summary>
        /// Historic District
        /// </summary>
        public string HistoricDistrict { get; set; }

        /// <summary>
        /// Other Hearing Date
        /// </summary>
        public string OtherHearingDate { get; set; }

        /// <summary>
        /// Is Current
        /// </summary>
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Last Action
        /// </summary>
        public string LastAction { get; set; }

        /// <summary>
        ///  Prior Status
        /// </summary>
        public string PriorStatus { get; set; }

        /// <summary>
        ///  Record Type
        /// </summary>
        public string RecordType { get; set; }

        /// <summary>
        ///  Is Building
        /// </summary>
        public bool IsBuilding { get; set; }

        /// <summary>
        ///  Is Vacant Lot
        /// </summary>
        public bool IsVacantLot { get; set; }

        /// <summary>
        /// Is Secondary Building
        /// </summary>
        public bool IsSecondaryBuilding { get; set; }

        /// <summary>
        ///  Latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal? Longitude { get; set; }

        [JsonIgnore]
        public LpcReportModel LPCReport { get; set; }
    }
}
