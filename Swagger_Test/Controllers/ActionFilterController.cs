using System;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Swagger_Test.Controllers
{

    public class ActionFilterController : ApiController
    {
        [AllowAnonymous]
        public SummaryResult Get(string x)
        {
            return null;
        }

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
    
    public class SummaryResult
    {
        /// <summary>Total Cost.</summary>
        /// <value>Total Cost.</value>
        /// <example>6433.2</example>
        public double TotalCost { get; set; }

        /// <summary>Owner.</summary>
        public Owner Owner { get; set; }
    }

    public class Owner
    {
        /// <summary>Owner Name.</summary>
        /// <value>Owner Name.</value>
        /// <example>Michael</example>
        public string Name { get; set; }
    }
}
