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
        /// <summary>Sample integer</summary>
        public int integ { get; set; }
        /// <summary>Sample double</summary>
        public double doub { get; set; }
        /// <summary>Sample boolean</summary>
        public bool boolea { get; set; }
        /// <summary>Sample guid</summary>
        public Guid guid { get; set; }
        /// <summary>Sample DateTime</summary>
        public DateTime date { get; set; }
    }
}
