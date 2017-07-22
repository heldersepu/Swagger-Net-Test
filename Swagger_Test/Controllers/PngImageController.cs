using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class PngImageController : ImageBaseController
    {
        // POST: api/PngImage
        public HttpResponseMessage Post()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream("image.png", Color.Red, Color.Blue);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}
