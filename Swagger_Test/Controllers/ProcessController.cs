using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ProcessController : ApiController
    {
        // GET: api/Process
        public IHttpActionResult Get(string name = null)
        {
            var data = Process.GetProcesses().Select(x => new {
                x.Id, x.ProcessName
            });
            if (!string.IsNullOrEmpty(name))
                data = data.Where(x => x.ProcessName.Contains(name));
            return Ok(data);
        }
    }
}
