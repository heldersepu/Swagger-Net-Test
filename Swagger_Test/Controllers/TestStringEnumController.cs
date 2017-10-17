using System.Web.Http;
using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Controllers
{
    public class MyEndpointRequestClass
    {
        [RegularExpression("^(dark-blue|dark-red|light-blue|light-red)")]
        public string StringEnumColor { get; set; }

        [RegularExpression("^(high|medium|low)")]
        public string Transparency { get; set; }

        public string Name { get; set; }
    }

    public class TestStringEnumController : ApiController
    {
        public string Get([FromUri] MyEndpointRequestClass r)
        {
            return r.StringEnumColor;
        }       
    }
}
