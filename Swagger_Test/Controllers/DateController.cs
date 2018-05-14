using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class DateController : ApiController
    {
        public Dates Get(Dates d)
        {
            return d;
        }
    }

    public class Dates
    {
        public DateTime D1 { get; set; }
        public NodaTime.LocalDate D2 { get; set; }
        public NodaTime.LocalTime D3 { get; set; }
        public NodaTime.LocalDateTime D4 { get; set; }
    }
}
