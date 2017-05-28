using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    public class IHttpActionResultController : ApiController
    {
        // GET: api/IHttpActionResult
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/IHttpActionResult/{id}
        [ResponseType(typeof(IEnumerable<int>))]
        public IHttpActionResult GetById(int id)
        {
            if (id > 0)
                return Ok(new int[] { 1, 2 });
            else
                return BadRequest("id must be greater than 0");
        }

        public IHttpActionResult Post()
        {
            throw new NotImplementedException();
        }
    }
}
