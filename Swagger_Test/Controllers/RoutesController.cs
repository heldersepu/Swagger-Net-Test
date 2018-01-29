using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("faux/RoutePrefix")]
    public class RoutesController : ApiController
    {
        public string Get()
        {
            return "RoutePrefix_Get";
        }

        [Route("{id:int}")]
        public string GetById(int id)
        {
            return "RoutePrefix_GetById";
        }

        [Route("one")]
        [Route("two")]
        public string Post(int id)
        {
            return "Post";
        }
    }
}
