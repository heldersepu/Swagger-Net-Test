using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class Int64Controller : ApiController
    {
        // GET: api/Int64
        public Int64Data Get()
        {
            return new Int64Data(1253261109769874438);
        }

        public class Int64Data
        {
            /// <example>1253261109769874438</example>
            public long MyInt64 { get; set; }
            /// <example>1253261109769874438</example>
            public string MyData { get; set; }

            public Int64Data(long int64)
            {
                MyInt64 = int64;
                MyData = int64.ToString();
            }
        }
    }
}
