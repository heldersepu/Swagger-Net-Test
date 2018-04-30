using System.IO;
using System.Reflection;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ResourcesController : ApiController
    {
        public string Get()
        {
            foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (name.EndsWith("js"))
                {
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
                    return new StreamReader(stream).ReadToEnd();
                }
            }
            return null;
        }
    }
}
