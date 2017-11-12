using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class CompanyController : ApiController
    {
        public Company Get()
        {
            return new Company {
                Id = 1,
                Name = "Co",
                Description = "Test Co"
            };
        }

        public IHttpActionResult Post([FromBody] IEnumerable<Company> companies)
        {
            return Ok(companies);
        }

        public IHttpActionResult Put([FromBody] List<Company> companies)
        {
            return Ok(companies);
        }
    }
}
