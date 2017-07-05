using System;

namespace CoreDataStore.Service.Models
{
    public class LPCReportModel
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

        /// <summary>
        /// LPC Web Site Photo Url
        /// </summary>
        public string PhotoURL
        {
            get
            {
                string baseUrl = null;
                if (this.PhotoStatus)
                    baseUrl = string.Format("https://corecdn.azureedge.net/images/{0}.jpg", this.LPCId);

                return baseUrl;
            }
        }

        /// <summary>
        /// LPC Designation Report Link
        /// </summary>
        public string PdfURL
        {
            get
            {
                string baseUrl = string.Format("http://s-media.nyc.gov/agencies/lpc/lp/{0}.pdf", this.LPCId);
                return baseUrl;
            }
        }

        /// <summary>
        /// NYCity Map
        /// </summary>
        public string MapURL
        {
            get
            {
                string baseUrl = null;
                if (this.ObjectType != "Historic District" && !string.IsNullOrWhiteSpace(this.Street) && !string.IsNullOrWhiteSpace(this.Borough))
                    baseUrl = string.Format("http://maps.nyc.gov/doitt/nycitymap/?searchType=AddressSearch&street={0}&borough={1}", this.Street, this.Borough);

                return baseUrl;
            }
        }

    }
}
