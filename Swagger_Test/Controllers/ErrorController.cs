using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpGet]
        [HttpPost]
        public string Error()
        {
            return "ERROR";
        }
    }
}
