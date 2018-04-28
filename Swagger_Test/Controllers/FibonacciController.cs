using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class FibonacciController : ApiController
    {
        [HttpGet]
        public Dictionary<int,int> FibA([Range(0, 100)] int num = 10)
        {
            var d = new Dictionary<int, int> { { 0, 0 } };
            for (int i = 1; i <= num; i++)
                d.Add(i, Fib(i));
            return d;
        }

        [HttpPost]
        public int Fib([Range(0,100)] int num = 10)
        {
            return (num < 2) ? num : Fib(num - 1) + Fib(num - 2);
        }
    }
}
