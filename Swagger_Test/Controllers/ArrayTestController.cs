using Newtonsoft.Json;
using Swagger_Test.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("api/ArrayTest")]
    public class ArrayTestController : ApiController
    {
        ///<summary>Get1 ##Get1</summary>
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

        ///<summary>Get2 `Get2`</summary>
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

        ///<summary>Get3 **Get3**</summary>
        /// <remarks>
        /// <a href="#Int64Post">See also the Int64 Post</a>
        /// <a href="#/IntParam/IntParam_Get">See also the IntParam Get</a>
        /// </remarks>
        [Route("list_location")]
        public List<Location> Get3([FromUri] List<Location> p)
        {
            return p;
        }

        /// <summary>
        /// Getting a sample json as param
        /// </summary>
        /// <param name="locations">[{Lat:1,Lon:2},{Lat:4,Lon:5}]</param>
        /// <returns></returns>
        [Route("json_locations")]
        public List<Location> Get3(string locations)
        {
            var p = JsonConvert.DeserializeObject<List<Location>>(locations);
            return p;
        }

        [Route("Arrays")]
        [Obsolete("This endpoint will no longer be supported. Use /api/somepath instead")]
        public Arrays Get4()
        {
            return new Arrays();
        }

        ///<summary>Post</summary>
        /// <remarks>
        /// Testing Markdown table
        /// | a | b | c | d | e |
        /// |---|---|---|---|---|
        /// | 3 | 0 | 7 | 4 | 1 |
        /// | 4 | 1 | 8 | 5 | 2 |
        /// | 5 | 2 | 9 | 6 | 3 |
        /// </remarks>
        [Route("Post Arrays")]
        public Arrays Post(Arrays arrays)
        {
            return arrays;
        }

        ///<summary>Put</summary>
        /// <remarks>
        /// ### This is a list
        /// - Item one
        /// - Item 2
        ///   - Sub item 1
        ///   - Sub item 2
        /// - Item 3
        /// </remarks>
        [Route("Test#Hash")]
        public Arrays Put(Arrays arrays)
        {
            return arrays;
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
