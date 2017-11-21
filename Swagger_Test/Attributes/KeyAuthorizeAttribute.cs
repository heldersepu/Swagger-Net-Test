using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Swagger_Test
{
    public enum Role { Admin, User }

    public class KeyAuthorizeAttribute : AuthorizeAttribute
    {
        Role _role = Role.User;
        public KeyAuthorizeAttribute() { }
        public KeyAuthorizeAttribute(Role role)
        {
            _role = role;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IEnumerable<string> apiKey = null;
            if (actionContext.Request.Headers.TryGetValues("apiKey", out apiKey))
            {
                switch (_role)
                {
                    case Role.Admin:
                        return apiKey.First() == "!@#$%^";
                    case Role.User:
                        return apiKey.First() == "123456";
                }                
            }
            return false;
        }
    }
}