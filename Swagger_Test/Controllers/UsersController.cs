using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<string> Post(User[] users)
        {
            return users.Select(x => x.Name);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
