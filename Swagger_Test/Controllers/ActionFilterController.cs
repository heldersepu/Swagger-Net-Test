using System;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Swagger_Test.Controllers
{

    public class ActionFilterController : ApiController
    {
        [CustomAuthorize()]
        public string Post(string x)
        {
            return x;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public int SecurityCheck { get; set; }
    }
}
