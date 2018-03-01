using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    public class Location
    {
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        [Range(-180, 180)]
        public decimal Lon { get; set; }
    }
}