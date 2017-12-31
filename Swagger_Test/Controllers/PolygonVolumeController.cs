using System.Collections.Generic;
using System.Web.Http;
using Swagger_Test.Models;

namespace Swagger_Test.Controllers
{
    public class PolygonVolumeController : ApiController
    {
        public PolygonVolumeInsideParameter Get([FromUri]PolygonVolumeInsideParameter p)
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
}
