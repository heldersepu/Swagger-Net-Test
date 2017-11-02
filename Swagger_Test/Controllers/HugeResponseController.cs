using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class HugeResponseController : ApiController
    {
        // GET: api/HugeResponse
        public IEnumerable<string> Get(int max = 100000)
        {
            var huge = new List<string>();
            huge.Add("Testing large responses");
            for (int i = 0; i < max; i++)
            {
                huge.Add(i.ToString());
                huge.Add(DateTime.Now.Ticks.ToString());
            }
            return huge;
        }
    }
}
