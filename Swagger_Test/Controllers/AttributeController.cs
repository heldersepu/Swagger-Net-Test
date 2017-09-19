using System;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("attrib")]
    public class AttributeController : ApiController
    {
        [Route("{payId?}")]
        public string Get(int payId = 123)
        {
            return $"{payId}";
        }

        [Route("data")]
        public Data Get([FromUri]Data data)
        {
            return data;
        }

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
        public int integ { get; set; }
        public double doub { get; set; }
        public bool boolea { get; set; }
        public Guid guid { get; set; }
        public DateTime date { get; set; }
    }
}
