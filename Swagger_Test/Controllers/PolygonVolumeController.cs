using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class PolygonVolumeController : ApiController
    {
        public PolygonVolumeInsideParameter Get(PolygonVolumeInsideParameter p)
        {
            return p;
        }

        public PolygonVolumeInsideParameter Post(PolygonVolumeInsideParameter p)
        {
            return p;
        }
    }

    public class PolygonVolumeInsideParameter
    {
        public List<Location> Points { get; set; }
        public string PlanId { get; set; }
    }
    public class Location
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
}
