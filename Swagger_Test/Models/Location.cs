using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    public class Location
    {
        /// <example>25.85</example>
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        /// <example>-80.27</example>
        [Range(-180, 180)]
        public decimal Lon { get; set; }
    }
}