using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class MyEndpointRequestClass 
    {
        //[StringEnum("dark-blue", "dark-red", "light-blue", "light-red")]
        public string StringEnumColor { get; set; }

        public string Name { get; set; }
    }

    public class TestStringEnumController : ApiController
    {
        public string Get(MyEndpointRequestClass r)
        {
            return r.StringEnumColor;
        }       
    }
}
