using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class MyTest
    {
        public string Name { get; set; }
        public bool IsPassing { get; set; }
    }

    public class TestPostController : ApiController
    {
        [HttpPost]
        public MyTest CreateTest(MyTest test)
        {
            return test;
        }

        public decimal Get(decimal x = 989898989898989898, decimal y = 1)
        {
            return x * y;
        }
    }
}
