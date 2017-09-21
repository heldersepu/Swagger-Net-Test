using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("Blob")]
    public class BlobController : ApiController
    {
        /// <summary>
        /// Get a Bad Blob
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        [Route("GetBad")]
        public string GetBad(Guid id, int? includes = null)
        {
            return "Bad";
        }

        /// <summary>
        /// Get an Ok Blob
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        [Route("GetOk")]
        public string GetOk(Guid id, int includes = 0)
        {
            return "Ok";
        }
    }
}
