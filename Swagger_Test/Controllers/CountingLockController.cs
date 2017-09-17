using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/CountingLock")]
    public class CountingLockController : ApiController
    {
        [Route("Get1")]
        public CountingLock1 Get1([FromUri] CountingLock1 c1)
        {
            return c1;
        }

        [Route("Get2")]
        public CountingLock2 Get2([FromUri] CountingLock2 c2)
        {
            return c2;
        }
    }
}
