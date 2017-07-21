using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class ImageController : ImageBaseController
    {
        // GET: api/Image
        public HttpResponseMessage Get()
        {
            string filePath = FilePath("imageGet.png");
            if (!File.Exists(filePath))
                CreateImage(filePath, Color.Red, Color.Cyan);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // POST: api/Image
        public HttpResponseMessage Post()
        {
            string filePath = FilePath("imagePost.png");
            if (!File.Exists(filePath))
                CreateImage(filePath, Color.White, Color.Blue);
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}

