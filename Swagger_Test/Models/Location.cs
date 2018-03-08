using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    /// <summary>
    /// ## Geographic coordinates
    /// ___
    /// A **geographic coordinate system** is a coordinate system used in geography that enables every location on Earth
    /// </summary>
    public class Location
    {
        /// <summary>Latitude</summary>
        /// <example>25.85</example>
        [Range(-90, 90)]
        public float Lat { get; set; }

        /// <summary>Longitude</summary>
        /// <example>-80.27</example>
        [Range(-180, 180)]
        public float Lon { get; set; }
    }
}