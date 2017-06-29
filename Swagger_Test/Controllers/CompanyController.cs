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
    }
}
