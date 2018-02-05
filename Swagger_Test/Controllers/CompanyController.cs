using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class CompanyController : ApiController
    {
        /// <remarks>
        /// ## TESTING MARKDOWN TABLES
        /// ### start table
        ///
        /// | Tables        | Are           | Cool  |
        /// | ------------- |:-------------:| -----:|
        /// | col 3 is      | right-aligned | $1600 |
        /// | col 2 is      | centered      |   $12 |
        /// | zebra stripes | are neat      |    $1 |
        ///
        /// ### end table
        /// </remarks>
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
