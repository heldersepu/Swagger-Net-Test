using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class NullablesController : ApiController
    {
        public List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    Name = "Foo",
                    Email = "foo@bar.com",
                    UserRole = UserRole.Admin,
                    Address = null
                }
            };
        }

        public class TestUser
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public UserRole UserRole { get; set; }
            public string Address { get; set; }
        }

        public enum UserRole
        {
            Admin,
            Moderator,
            Member
        }
    }
}
