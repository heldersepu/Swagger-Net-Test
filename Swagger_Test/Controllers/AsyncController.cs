using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("Async")]
    public class AsyncController : ApiController
    {
        [Route("")]
        public async Task<IEnumerable<string>> Get()
        {
            await Task.Delay(10);
            return new string[] { "value1", "value2" };
        }

        [Route("MyService/{myParameter}")]
        public async Task<string> Get(int myParameter)
        {
            await Task.Delay(10);
            return "value";
        }

        [Route("")]
        public async Task Post([FromBody]string value)
        {
            await Task.Delay(10);
        }

        [Route("{id}")]
        public async Task Put(int id, [FromBody]string value)
        {
            await Task.Delay(10);
        }

        [Route("{id}")]
        public async Task Delete(int id)
        {
            await Task.Delay(10);
        }
    }
}
