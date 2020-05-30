using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class IntParamController : ApiController
    {
        public Payload Get([FromUri]Payload data)
        {
            return data;
        }
        
        public int Post([FromUri] [Range(1, 10)] int value)
        {
            return value;
        }
    }

    public class Payload
    {
        /// <summary>Payload Name</summary>
        public string Name { get; set; }

        /// <summary> Timeout in ms (Range 15000 to 60000. Default set to 50000) </summary>
        [DefaultValue(50000)]
        [Range(15000, 60000)]
        public int Timeout { get; set; }
    }
}
