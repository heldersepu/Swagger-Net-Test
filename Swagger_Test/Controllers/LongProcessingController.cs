using System.Threading;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class LongProcessingController : ApiController
    {
        /// <summary>
        /// This action will put the thread to sleep for the given amount of seconds.
        /// </summary>
        /// <param name="seconds">How many seconds to sleep</param>
        /// <returns>The provided seconds</returns>
        public int Get(int seconds = 25)
        {
            Thread.Sleep(seconds * 1000);
            return seconds;
        }
    }
}
