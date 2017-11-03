using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class CustomEnumerableController : ApiController
    {
        // GET: api/CustomEnumerable
        public MyEnumerable Get()
        {
            var data = new MyEnumerable();
            return new MyEnumerable();
        }
    }

    public class MyEnumerable : IEnumerable<int>
    {
        static Random rnd = new Random();
        //public int Count { get { return Items.Count; } }

        private IList<int> Items
        {
            get
            {
                var data = new List<int>();
                for (int i = 0; i < rnd.Next(5, 10); i++)
                    data.Add(rnd.Next(100, 999));
                return data;
            }                
        }

        public IEnumerator<int> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
