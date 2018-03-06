using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ApiVersionController : ApiController
    {
        [Route("v1/{id:int}")]
        [Route("v2/{id:int}")]
        public string GetById(int id)
        {
            return "ApiVersion_GetById";
        }
    }
}
