using Swagger_Test.Models;
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

        [Route("PostTest1")]
        public IHttpActionResult PostTest1(test1 x)
        {
            return Ok(x);
        }

        [Route("PostTest2")]
        public IHttpActionResult PostTest2(test2 x)
        {
            return Ok(x);
        }
    }
}
