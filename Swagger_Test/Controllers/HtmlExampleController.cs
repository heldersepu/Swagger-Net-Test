using Swagger.Net.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class HtmlExampleController : ApiController
    {
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(string), mediaType: "text/html")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(Example, Encoding.UTF8, "text/html")
            };
        }

        private static string Example
        {
            get
            {
                return @"
                    <!DOCTYPE html>
                    <html>
                        <head></head>
                        <body>
                            <h1>hello</h1>
                        </body>
                    </html>";
            }
        }
    }
}
