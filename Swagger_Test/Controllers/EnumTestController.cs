using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class EnumTestController : ApiController
    {
        public ShiftDayOffRule Get(ShiftDayOffRule rule)
        {
            return rule;
        }

    }
}
