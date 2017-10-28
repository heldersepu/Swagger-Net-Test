using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

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
