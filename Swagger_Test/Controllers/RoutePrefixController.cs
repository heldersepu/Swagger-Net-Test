using Swagger_Test.Models;
using System.Threading.Tasks;
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

        [Route("my/put1/{date}")]
        public Task<IHttpActionResult> Put1(LocalDate date, InputModel inputModel)
        {
            return null;
        }

        [Route("my/post1/{date}")]
        public Task<IHttpActionResult> Post1(LocalDate date, InputModel inputModel)
        {
            return null;
        }

        [Route("my/put2")]
        public Task<IHttpActionResult> Put2(LocalDate date, InputModel inputModel)
        {
            return null;
        }

        [Route("my/post2")]
        public Task<IHttpActionResult> Post2(LocalDate date, InputModel inputModel)
        {
            return null;
        }
    }

    public class LocalDate { long id; string name; }
    public class InputModel { int id; string name; }


}
