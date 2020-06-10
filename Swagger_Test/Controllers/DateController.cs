using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class DateController : ApiController
    {
        public Dates Post([FromBody] Dates d)
        {
            return d;
        }
    }

    public class Dates
    {
        [JsonConverter(typeof(DateFormatConverter))]
        public DateTime D0 { get; set; }
        /// <example>2020-05-31</example>
        public DateTime D1 { get; set; }
        public NodaTime.LocalDate D2 { get; set; }
        public NodaTime.LocalTime D3 { get; set; }
        public NodaTime.LocalDateTime D4 { get; set; }
    }

    public  class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
