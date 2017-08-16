using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    public class MultiGetController : ApiController
    {
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult Get(int bId)
        {
            return Ok();
        }

        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetByList(IList<int> cIds)
        {
            return Ok();
        }

        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetByIdAndList(int bId, IList<int> cIds)
        {
            return Ok();
        }
    }
}
