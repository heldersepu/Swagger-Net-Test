using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("foos/{fooId}/bars/{barId}/widgets")]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public List<string> GetById(int id)
        {
            return new List<string> { "value1", "value2" };
        }
    }
}
