using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class LogController : ApiController
    {
        private static NLog.Logger nlg = NLog.LogManager.GetCurrentClassLogger();
        private static log4net.ILog l4n = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IHttpActionResult Get()
        {
            nlg.Info("Test1");
            nlg.Error("Test2");

            l4n.Info("Test1");
            l4n.Error("Test2");

            return Ok();
        }
    }
}
