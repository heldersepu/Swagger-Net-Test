using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/MultiGet")]
    public class MultiGetController : ApiController
    {
        [Route("")]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult Get(int bId)
        {
            return Ok();
        }

        [Route("ByList")]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetByList(List<int> cIds)
        {
            return Ok();
        }

        [Route("ByIList")]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetByIList(IList<int> cIds)
        {
            return Ok();
        }

        [Route("ByIdAndList")]
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetByIdAndList(int bId, IList<int> cIds)
        {
            return Ok();
        }
    }
}
