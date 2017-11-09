using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class EnumTestController : ApiController
    {
        public string Get(ShiftDayOffRule rule)
        {
            return "test";
        }

    }
}
