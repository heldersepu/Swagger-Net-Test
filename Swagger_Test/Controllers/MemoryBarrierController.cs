using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class MemoryBarrierController : ApiController
    {
        // GET: api/MemoryBarrier
        public bool Get()
        {
            bool ret = false;
#if HAVE_MEMORY_BARRIER
            ret = true;
#endif
            return ret;
        }
    }
}
