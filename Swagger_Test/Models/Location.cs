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
        /// <summary>**Latitude**: a geographic coordinate that specifies the north–south position of a point on the Earth's surface.</summary>
        /// <example>25.85</example>
        [Range(-90, 90)]
        public float Lat { get; set; }

        /// <summary>**Longitude**: a geographic coordinate that specifies the east-west position of a point on the Earth's surface.</summary>
        /// <example>-80.27</example>
        [Range(-180, 180)]
        public float Lon { get; set; }
    }

    public class Coordinate : Location
    {
        /// <summary>**Elevation**: is the height above or below a fixed reference point.</summary>
        /// <example>2.6</example>
        public float Elev { get; set; }
    }
}