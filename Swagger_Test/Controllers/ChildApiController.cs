using Swagger.Net.Annotations;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    abstract public class BaseApiController : ApiController
    {
        [HttpGet]
        [Route("/api/data")]
        [SwaggerOperation("GetData")]
        [SwaggerResponse(200, type: typeof(List<Data>))]
        public virtual IHttpActionResult GetData()
        {
            string exampleJson = null;

            return Ok(exampleJson);
        }
    }

    public class ChildApiController : BaseApiController
    {
        public override IHttpActionResult GetData()
        {
            return base.GetData();
        }
    }
}
