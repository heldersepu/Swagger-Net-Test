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

        /// <remarks>
        /// <a href="#Int64Post">See also the Int64 Post</a>
        /// <a href="#/IntParam/IntParam_Get">See also the IntParam Get</a>
        /// </remarks>
        [Route("list_location")]
        public List<Location> Get3([FromUri] List<Location> p)
        {
            return p;
        }

        [Route("Arrays")]
        public Arrays Get4()
        {
            return new Arrays();
        }

    }

    public class Arrays
    {
        /// <summary>Test</summary>
        public List<string> array1;

        public HashSet<string> array2;

        public string[] array3;

        /// <summary>List of Companies</summary>
        public List<Data> array4;
    }
}
