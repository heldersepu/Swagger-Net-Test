using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

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
        [SwaggerResponse(HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(BadRequestErrorMessageResult))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        public IHttpActionResult GetById(int id)
        {
            if (id > 0)
                return Ok(new int[] { 1, 2 });
            else if (id == 0)
                return NotFound();
            else
                return BadRequest("id must be greater than 0");
        }

        public IHttpActionResult Post()
        {
            throw new NotImplementedException();
        }
    }
}
