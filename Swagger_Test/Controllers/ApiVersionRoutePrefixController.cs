using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("v1_0/test1")]
    public class ApiVersionRoutePrefix1Controller : ApiController
    {
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "ApiVersionRoutePrefix1_Get";
        }
    }

    [RoutePrefix("v2_0/test2")]
    public class ApiVersionRoutePrefix2Controller : ApiController
    {
        [Route("{id:int}")]
        public string Get(int id)
        {
            return "ApiVersionRoutePrefix1_Get";
        }
    }
}
