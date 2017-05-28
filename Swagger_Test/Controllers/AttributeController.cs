using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("attrib")]
    public class AttributeController : ApiController
    {
        [Route("{name}")]
        public Data Post([FromUri]string name)
        {
            return new Data();
        }

        [Route("{id}")]
        public Data Post([FromBody]int id)
        {
            return new Data();
        }
    }

    public class Data
    {
        public int integ = 1;
        public double doub = 1.1;
        public bool boolea = false;
        public Guid guid = Guid.NewGuid();
        public DateTime date = DateTime.Now;
    }
}
