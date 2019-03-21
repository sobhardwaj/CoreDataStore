using System;
using CoreDataStore.Service.Constants;

namespace CoreDataStore.Service.Models
{
    public class LpcReportModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string LPCId { get; set; }

        public string LPNumber { get; set; }

        public string ObjectType { get; set; }

        public string Architect { get; set; }

        public string Style { get; set; }

        public string Street { get; set; }

        public string Borough { get; set; }

        public DateTime DateDesignated { get; set; }

        public bool PhotoStatus { get; set; }

        public bool MapStatus
        {
            get
            {
                if (this.ObjectType != "Historic District")
                    return true;

                return false;
            }

        }

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
                    baseUrl = $"{ReportConstants.LpcReportMapUri}?searchType=AddressSearch&street={this.Street}&borough={this.Borough}";

                return baseUrl;
            }
        }

    }
}
