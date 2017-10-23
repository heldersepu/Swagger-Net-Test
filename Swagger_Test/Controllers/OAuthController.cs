using System.Web;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class OAuthController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var obj = new
            {
                HttpContext.Current.User.Identity.AuthenticationType,
                HttpContext.Current.User.Identity.IsAuthenticated,
                HttpContext.Current.User.Identity.Name,
                RequestContext.Principal
            };
            return Ok(obj);
        }

        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var obj = new
            {
                HttpContext.Current.User.Identity.AuthenticationType,
                HttpContext.Current.User.Identity.IsAuthenticated,
                HttpContext.Current.User.Identity.Name,
                RequestContext.Principal
            };
            return Ok(obj);
        }
    }
}
