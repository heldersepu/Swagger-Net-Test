using System;
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

        public void Post([FromBody]string value)
        {
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
