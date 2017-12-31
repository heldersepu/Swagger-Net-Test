using Swagger_Test.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/ArrayTest")]
    public class ArrayTestController : ApiController
    {
        [Route("list_string")]
        public List<string> Get1([FromUri] List<string> p)
        {
            return p;
        }

        [Route("list_int")]
        public List<int> Get2([FromUri] List<int> p)
        {
            return p;
        }

        [Route("list_location")]
        public List<Location> Get3([FromUri] List<Location> p)
        {
            return p;
        }

    }
}
