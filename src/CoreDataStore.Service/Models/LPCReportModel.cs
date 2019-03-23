using System;
using System.Web;
using CoreDataStore.Service.Constants;

namespace CoreDataStore.Service.Models
{
    public class LpcReportModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///  Landmark Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  LPC Id
        /// </summary>
        public string LPCId { get; set; }

        /// <summary>
        /// LP Number
        /// </summary>
        public string LPNumber { get; set; }

        /// <summary>
        /// Object Type
        /// </summary>
        public string ObjectType { get; set; }

        /// <summary>
        /// Architect
        /// </summary>
        public string Architect { get; set; }

        /// <summary>
        /// Style
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Borough
        /// </summary>
        public string Borough { get; set; }

        /// <summary>
        /// Date Designated
        /// </summary>
        public DateTime DateDesignated { get; set; }

        /// <summary>
        /// Photo Status (Exists)
        /// </summary>
        public bool PhotoStatus { get; set; }

        /// <summary>
        /// Map Status (Exists)
        /// </summary>
        public bool MapStatus
        {
            get
            {
                if (this.ObjectType != "Historic District")
                    return true;

                return false;
            }

        }

        /// <summary>
        /// Neighborhood
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// LPC Web Site Photo Url
        /// </summary>
        public string PhotoURL
        {
            get
            {
                string baseUrl = null;
                if (PhotoStatus)
                    baseUrl = $"{ReportConstants.LpcReportPhotoUri}/{LPCId}.jpg";

                return baseUrl;
            }
        }

        /// <summary>
        /// LPC Designation PDF Report Link
        /// </summary>
        public string PdfURL => $"{ReportConstants.LpcReportPdfUri}/{LPCId}.pdf";

        /// <summary>
        /// NY City Map
        /// </summary>
        public string MapURL
        {
            get
            {
                string baseUrl = null;
                if (ObjectType != "Historic District" && !string.IsNullOrWhiteSpace(Street) && !string.IsNullOrWhiteSpace(this.Borough))
                    baseUrl = $"{ReportConstants.LpcReportMapUri}?searchType=AddressSearch&street={HttpUtility.UrlEncode(this.Street)}&borough={this.Borough}";

                return baseUrl;
            }
        }
    }
}
