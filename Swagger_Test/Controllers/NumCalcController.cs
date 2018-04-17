using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class NumCalcController : ApiController
    {
        public double Get(long max = 1000000)
        {
            double total = 0;
            for (long i = 1; i < max; i++)
                total += 1/(double)i;
            return total;
        }
    }
}
