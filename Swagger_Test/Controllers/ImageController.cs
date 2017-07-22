using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class ImageController : ImageBaseController
    {
        // GET: api/Image
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream("imageGet.png", Color.Red, Color.Cyan);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // POST: api/Image
        public HttpResponseMessage Post()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream("imagePost.png", Color.White, Color.Blue);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}

