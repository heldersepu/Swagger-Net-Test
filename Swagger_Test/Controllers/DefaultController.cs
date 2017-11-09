using Swagger_Test.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("foos/{fooId}/bars/{barId}/widgets")]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public string Get()
        {
            return Request.Headers.Referrer.AbsoluteUri;
        }

        // GET: api/Default/5
        public List<string> GetById(int id)
        {
            return new List<string> { "value1", "value2" };
        }

        public string Put(NewUserWriteModel model)
        {
            return "TEST";
        }

        public ShiftDayOffRule Post(ShiftDayOffRule dayOffRule)
        {
            return dayOffRule;
        }

        [IgnoreSwaggerUiRequest]
        public string Delete(int id)
        {
            return "TEST";
        }
    }
}
