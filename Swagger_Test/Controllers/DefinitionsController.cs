using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class DefinitionsController : ApiController
    {
        public Task<CurrentTask> Get()
        {
            return null;
        }
    }

    public class CurrentTask
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public object Payload { get; set; }
    }

    [ContractClass(typeof(CurrentTask))]
    public class Task1Payload
    {
        public string Text { get; set; }
    }

    [ContractClass(typeof(CurrentTask))]
    public class Task2Payload
    {
        public string PictureUrl { get; set; }
    }
}
