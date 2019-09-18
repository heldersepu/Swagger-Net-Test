using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class MData
    {
        public int NumId { get; set; }
        public MonthEnum Month { get; set; }
    }

    public class MonthTestController : ApiController
    {
        public MData Get([FromUri]MData data)
        {
            return data;
        }

        /// <summary>
        /// This is a sumary.
        /// </summary>
        /// <remarks>
        /// This is a test:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        public MonthEnum Post(MonthEnum month = MonthEnum.July)
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
