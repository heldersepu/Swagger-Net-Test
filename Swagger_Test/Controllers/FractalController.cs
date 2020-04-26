using Swagger.Net.Annotations;
using System;
using System.Drawing;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Swagger_Test.Controllers
{
    public class FractalController : ImageBaseController
    {
        // GET: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Get(int width, int height, int zoom, int iterations)
        {
            var response = new HttpResponseMessage();
            response.Content = MandelbrotImageStream(width, height, zoom, iterations);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}
