using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("MultiParamPost")]
    public class MultiParamPostController : ApiController
    {
        [Route("{id}")]
        public Company Post(Guid id, List<Company> companies)
        {
            return companies.FirstOrDefault();
        }
    }
}
