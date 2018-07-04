using Newtonsoft.Json;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class SymbolsController : ApiController
    {
        public Symbols Post(Symbols x)
        {
            return x;
        }
    }

    public class Symbols
    {
        [JsonProperty(PropertyName = "@id")]
        public int @id;
        [JsonProperty(PropertyName = "@name")]
        public string @name;
        [JsonIgnore]
        public string details;
    }
}
