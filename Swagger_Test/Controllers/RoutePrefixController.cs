using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("foo/widgets")]
    public class RoutePrefixController : ApiController
    {
        [Route("")]
        public string Get()
        {
            return "value";
        }

        [Route("{id}")]
        public string GetById(string id)
        {
            return "value " + id;
        }

        [Route("{id}/{name}")]
        public string GetByIdByName(string id, string name)
        {
            return "value " + id + " " + name;
        }
    }
}
