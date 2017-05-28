using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Swagger_Test.Controllers
{
    public class DictionaryController : ApiController
    {
        // GET: api/Dictionary
        [ResponseType(typeof(Test))]
        public Test Get()
        {
            var d = new Dictionary<string, int>();
            for (int i = 0; i < 10; i++)
                d.Add(Guid.NewGuid().ToString(), i);
            return new Test { id = 99, index = d };
        }

        public Test PostEcho(Test test)
        {
            return test;
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
