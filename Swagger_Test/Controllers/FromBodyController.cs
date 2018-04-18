using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/FromBody")]
    public class FromBodyController : ApiController
    {
        [Route("Test0_WithFromBody")]
        public IHttpActionResult GetWith0([FromBody] ViewModelTest a, [FromBody] ViewModelTest b)
        {
            return Ok(new { a = a, b = b });
        }

        [Route("Test1_WithFromBody")]
        public ViewModelTest GetWith([FromBody] ViewModelTest v)
        {
            return v;
        }

        [Route("Test2_NoFromBody")]
        public ViewModelTest GetWithout(ViewModelTest v)
        {
            return v;
        }

        public ViewModelTest Post(ViewModelTest v)
        {
            return v;
        }
    }
}
