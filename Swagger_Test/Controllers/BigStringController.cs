using System;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class BigStringController : ApiController
    {
        // GET: api/BigString/5
        public string Get(int max = 10000)
        {
            var big = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                big.Append(" ");
                big.Append(i.ToString());
                big.Append(",");
                big.Append(DateTime.Now.Ticks.ToString());
            }
            return big.ToString();
        }
    }
}
