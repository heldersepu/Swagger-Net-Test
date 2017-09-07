using System.Web;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class OAuthController : ApiController
    {
        public IHttpActionResult Get()
        {
            var obj = new
            {
                HttpContext.Current.User.Identity.AuthenticationType,
                HttpContext.Current.User.Identity.IsAuthenticated,
                HttpContext.Current.User.Identity.Name
            };
            return Ok(obj);
        }
    }
}
