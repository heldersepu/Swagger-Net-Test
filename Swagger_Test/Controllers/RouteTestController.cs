using System.ComponentModel;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    /// <summary>
    /// Testing a controller with param in the Route
    /// </summary>
    [RoutePrefix("api/RouteTest")]
    public class RouteTestController : ApiController
    {
        [Route("test/{itemid:int}")]
        public DTOv2 Get([FromUri] DTOv2 data)
        {
            return data;
        }
    }

    public class DTOv2
    {
        /// <summary>Secret ID for your object</summary>
        /// <example>234</example>
        [DefaultValue(123)]
        public int itemid { get; set; }


        /// <summary>Notes about your object</summary>
        /// <example>MyNote</example>
        [DefaultValue("HelloWorld")]
        public string note { get; set; }
    }
}
