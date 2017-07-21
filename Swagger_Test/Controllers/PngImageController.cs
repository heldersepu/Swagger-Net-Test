using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class PngImageController : ImageBaseController
    {
        // POST: api/PngImage
        public HttpResponseMessage Post()
        {
            string filePath = FilePath("imagePost.png");
            if (!File.Exists(filePath))
                CreateImage(filePath, Color.Red, Color.Blue);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}
