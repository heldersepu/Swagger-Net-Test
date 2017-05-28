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
    }
}
