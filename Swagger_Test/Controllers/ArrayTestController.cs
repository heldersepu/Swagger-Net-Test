using Swagger_Test.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/ArrayTest")]
    public class ArrayTestController : ApiController
    {
        /// <remarks>
        /// Testing Markdown
        /// *Italic*
        /// **Bold**
        /// # Heading 1
        /// ## Heading 2
        /// [Link](http://a.com)
        /// * List abc
        /// * List def
        /// * List ghi
        ///
        /// > Blockquote
        /// `Inline code` with backticks
        /// Horizontal Rule
        /// ---
        /// Block1 Line1
        /// Block1 Line2
        ///
        /// Block2 Line1
        /// Block2 Line2
        /// </remarks>
        [Route("list_string")]
        public List<string> Get1([FromUri] List<string> p)
        {
            return p;
        }

        /// <remarks>
        /// HelloWorld
        /// <pre>{
        ///     "demo": "val", 
        ///     "demo2": "hello"
        /// }</pre>
        /// </remarks>
        [Route("list_int")]
        public List<int> Get2([FromUri] List<int> p)
        {
            return p;
        }

        [Route("list_location")]
        public List<Location> Get3([FromUri] List<Location> p)
        {
            return p;
        }

    }
}
