using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class Blob<T> : ApiController
    {
        /// <summary> Get a Bad Blob </summary>
        public string GetBad(int? x)
        {
            return "Bad";
        }

        /// <summary> Get an Ok Blob </summary>
        public string PostOk(int x)
        {
            return "Ok";
        }

        /// <summary> Template object test </summary>
        public string Put(AnotherFoo<T> x)
        {
            return "Gets a template";
        }
    }

    public class Foo { }

    public class AnotherFoo<TV> { }

    public class BlobController : Blob<Foo> { }
}
