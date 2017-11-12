using Swagger.Net.Annotations;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class ImageController : ImageBaseController
    {
        // GET: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.Red, Color.Cyan);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // POST: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Post()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.White, Color.Blue);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // PUT: api/Image
        [SwaggerResponse(200, "image.png", mediaType: "application/octet-stream")]
        public HttpResponseMessage Put()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.White, Color.Black);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment") { FileName = "image.png" };
            return response;
        }
    }
}

