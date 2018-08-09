using Swagger.Net.Annotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class SvgImageController : ApiController
    {
        private HttpResponseMessage Image(string mediaType)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(
                "<svg><circle cx='50' cy='50' r='40' fill='red' /></svg>",
                Encoding.UTF8, "text/html"
            );
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            return response;
        }


        [SwaggerResponse(200, "image.svg", mediaType: "image/svg+xml")]
        public HttpResponseMessage Get()
        {
            return Image("image/svg+xml");
        }

        [SwaggerResponse(200, "image.svg", mediaType: "text/html")]
        public HttpResponseMessage Post()
        {
            return Image("text/html");
        }

        [SwaggerResponse(200, "image.svg", mediaType: "image/svg")]
        public HttpResponseMessage Put()
        {
            return Image("image/svg");
        }
    }
}
