using System.Collections;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class CustomEnumerableController : ApiController
    {
        // GET: api/CustomEnumerable
        public MyEnumerable Get()
        {
            return null;
        }
    }

    public class MyEnumerable : IEnumerable
    {
        public int Abc { get; }
        public int Def { get; }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
