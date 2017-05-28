using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("bind")]
    public class BindingController : ApiController
    {
        [Route("{id}")]
        public string Get([Bind]string id)
        {
            return "abc";
        }

        [Route("{id}")]
        public string Post(string id)
        {
            return "abc";
        }
    }

    public class BindAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor p)
        {
            return new FooBinding(p);
        }
    }
    public class FooBinding : HttpParameterBinding
    {
        public FooBinding(HttpParameterDescriptor d) : base(d) { }

        public override Task ExecuteBindingAsync(ModelMetadataProvider m, HttpActionContext a, CancellationToken c)
        {
            return Task.FromResult(true);
        }
    }
}
