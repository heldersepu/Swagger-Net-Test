namespace Swagger_Test.Models
{
    /// <summary>
    /// Geolocation result
    /// </summary>
    public class GeolocateResponse
    {
        /// <summary>
        /// Two-letter country code of IP address
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country name of IP address
        /// </summary>
        public string CountryName;

        /// <summary>
        /// City of IP address
        /// </summary>
        public string City;

        /// <summary>
        /// State/region code of IP address
        /// </summary>
        public string RegionCode;

        /// <summary>
        /// State/region of IP address
        /// </summary>
        public string RegionName;

        /// <summary>
        /// Zip or postal code of IP address
        /// </summary>
        public string ZipCode;

        /// <summary>
        /// Timezone of IP address
        /// </summary>
        public string TimezoneStandardName;

        /// <summary>
        /// Latitude of IP address
        /// </summary>
        public decimal Latitude;

        /// <summary>
        /// Longitude of IP address
        /// </summary>
        public decimal Longitude;
    }
}