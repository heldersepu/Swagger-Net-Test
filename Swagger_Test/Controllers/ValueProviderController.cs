using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace Swagger_Test.Controllers
{
    public class ValueProviderController : ApiController
    {
        public IHttpActionResult Get([ValueProvider(typeof(MyValueProviderFactory))] long id)
        {
            return Ok(new string[] { "value1", "value2" });
        }

        public long Post([FromBody]string value)
        {
            return DateTime.Now.Ticks;
        }

        public Dictionary<string, string> Put()
        {
            var dict = new Dictionary<string, string>();
            foreach (var header in Request.Headers)
                if (header.Key.EndsWith("id"))
                    dict.Add(header.Key, header.Value.First());
            return dict;
        }

        private class MyValueProviderFactory: ValueProviderFactory
        {
            public MyValueProviderFactory() { }

            public override IValueProvider GetValueProvider(HttpActionContext actionContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}
