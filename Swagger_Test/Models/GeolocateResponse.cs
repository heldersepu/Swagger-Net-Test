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
        /// <example>Miami</example>
        public string City;

        /// <summary>
        /// State/region code of IP address
        /// </summary>
        /// <example>FL</example>
        public string RegionCode;

        /// <summary>
        /// State/region of IP address
        /// </summary>
        /// <example>Florida</example>
        public string RegionName;

        /// <summary>
        /// Zip or postal code of IP address
        /// </summary>
        /// <example>33323</example>
        public string ZipCode;

        /// <summary>
        /// Timezone of IP address
        /// </summary>
        public string TimezoneStandardName;

        /// <summary>
        /// Latitude of IP address
        /// </summary>
        /// <example>25.85</example>
        public decimal Latitude;

        /// <summary>
        /// Longitude of IP address
        /// </summary>
        /// <example>-80.27</example>
        public decimal Longitude;
    }
}