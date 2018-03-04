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
    }
}
