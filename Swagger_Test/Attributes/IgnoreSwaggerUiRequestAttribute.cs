using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Swagger_Test
{
    public class IgnoreSwaggerUiRequestAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext a)
        {
            bool methodNotAllowed = false;
            try
            {
                methodNotAllowed = a.Request.Headers.Referrer.AbsoluteUri.Contains("swagger/ui");
            }
            catch { }
            if (methodNotAllowed)
            {
                a.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.MethodNotAllowed,
                    Content = new StringContent("This method is not allowed from the swagger ui")
                };
            }
        }
    }
}