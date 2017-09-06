using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class IActionResultController : ApiController
    {
        // GET: api/IActionResult
        public string[] GetListStuff(int foo, string auditId)
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/IActionResult
        public string[] PostListStuff(int foo, string auditId)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
