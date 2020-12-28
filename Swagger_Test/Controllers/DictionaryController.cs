using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    public class DictionaryController : ApiController
    {
        [AllowAnonymous]
        public Test Get()
        {
            var d = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                d.Add(Guid.NewGuid().ToString(), i);
            return new Test { id = 99, index = d };
        }

        [KeyAuthorize]
        public Test PostEcho([FromBody] List<Test> test)
        {
            return test.FirstOrDefault();
        }

        [KeyAuthorize(Role.Admin)]
        public Test PutEcho([FromBody] List<Test> test)
        {
            return test.FirstOrDefault();
        }

        public Dictionary<string, string>[] PatchEcho([FromBody]Dictionary<string, string>[] values)
        {
            return values;
        }

        public List<Guid> DeleteEcho([FromBody] List<Guid> guids)
        {
            return guids;
        }

        public class Test
        {
            public int id;
            public Guid guid;
            public double did;
            public List<string> keys;
            public Dictionary<string, int> index;
        }

    }
}
