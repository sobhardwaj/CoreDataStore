using CoreDataStore.Domain.Entities;
using CoreDataStore.Service.Constants;

namespace CoreDataStore.Service.Models
{
    public class LpcReportModel : LpcReport
    {
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
        public override string PhotoURL
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
