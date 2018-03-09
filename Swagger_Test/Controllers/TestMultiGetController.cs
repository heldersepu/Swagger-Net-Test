using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class TestMultiGetController : ApiController
    {
        public string Get()
        {
            return "Get1";
        }

        public string Get(int id)
        {
            return "Get2";
        }
    }
}
