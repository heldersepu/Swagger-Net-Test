using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class BlobController : ApiController
    {
        /// <summary> Get a Bad Blob </summary>
        public string GetBad(Guid id, int? includes = null)
        {
            return "Bad";
        }

        /// <summary> Get an Ok Blob </summary>
        public string PostOk(Guid id, int includes = 0)
        {
            return "Ok";
        }
    }

    public class Foo { }

    public class BlobTestController : BlobController { }
}
