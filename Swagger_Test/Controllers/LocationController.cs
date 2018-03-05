using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("Location")]
    public class LocationController : ApiController
    {
        [Route("Get1")]
        public GeolocateResponse Get1([FromUri] GeolocateResponse x)
        {
            return x;
        }

        [Route("Get2")]
        public Location Get2([FromUri] Location x)
        {
            return x;
        }

        [Route("Get3")]
        public SomeRequest Get3([FromUri] SomeRequest x)
        {
            return x;
        }
    }

    public class SomeRequest
    {
        public Location Point1 { get; set; }
        public Location Point2 { get; set; }
    }
}
