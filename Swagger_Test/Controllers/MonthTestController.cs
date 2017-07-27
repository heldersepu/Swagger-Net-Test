using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class MonthTestController : ApiController
    {
        public MonthEnum Get(MonthEnum month)
        {
            return month;
        }

        public MonthEnum Post(MonthEnum month)
        {
            return month;
        }

        public MonthEnum Put(MonthEnum month)
        {
            return month;
        }

        public MonthEnum Delete(MonthEnum month)
        {
            return month;
        }
    }
}
