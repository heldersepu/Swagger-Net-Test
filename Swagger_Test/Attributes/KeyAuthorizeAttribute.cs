using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Swagger_Test
{
    public class KeyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IEnumerable<string> apiKey = null;
            if (actionContext.Request.Headers.TryGetValues("apiKey", out apiKey))
            {
                return apiKey.First() == "123456";
            }
            return false;
        }
    }
}