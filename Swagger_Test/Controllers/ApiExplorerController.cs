using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ApiExplorerController : ApiController
    {
        // GET: api/ApiExplorer
        public IEnumerable<string> Get()
        {
            var apiEx = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return apiEx.ApiDescriptions.Select(a => $"{a.HttpMethod} {a.RelativePath}");
        }

    }
}
