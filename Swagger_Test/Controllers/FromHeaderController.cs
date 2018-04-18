using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/FromHeader")]
    public class FromHeaderController : ApiController
    {
        [Route("Test0_WithFromUri")]
        public IHttpActionResult GetWith0([FromHeader] string a, [FromHeader] string b)
        {
            return Ok(new { a = a, b = b });
        }

        [Route("Test1_WithFromHeader")]
        public string GetWith([FromHeader] string v)
        {
            return v;
        }

        [Route("Test2_NoFromHeader")]
        public string GetWithout(string v)
        {
            return v;
        }

        public string Post([FromHeader] string v)
        {
            return v;
        }
    }
}
