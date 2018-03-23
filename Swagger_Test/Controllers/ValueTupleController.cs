using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ValueTupleController : ApiController
    {
        // GET: api/ValueTuple
        public IHttpActionResult Get()
        {
            var unit = (10, 20, 'X');
            Tuple<int, int, char> tuple = unit.ToTuple();
            return Ok(tuple);
        }
    }
}
