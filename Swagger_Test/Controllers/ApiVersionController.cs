using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ApiVersionController : ApiController
    {
        [Route("v1_0/{id:int}")]
        [Route("v2_0/{id:int}")]
        public string GetById(int id)
        {
            return "ApiVersion_GetById";
        }
    }
}
