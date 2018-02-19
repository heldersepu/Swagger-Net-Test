using Swagger_Test.Models;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class NewUserController : ApiController
    {
        public NewUserWriteModel Get([FromUri] NewUserWriteModel data)
        {
            return data;
        }
    }
}
