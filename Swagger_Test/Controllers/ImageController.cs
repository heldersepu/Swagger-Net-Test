using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class ImageController : ApiController
    {
        // GET: api/Image
        public HttpResponseMessage Get()
        {
            string filePath = @"file.png";
            if (!File.Exists(filePath))
            {
                Bitmap bmp = new Bitmap(250, 50);
                for (int y = 0; y < bmp.Height; ++y)
                    for (int x = 0; x < bmp.Width; ++x)
                        bmp.SetPixel(x, y, (x % 5 == 0)? Color.Red : Color.Cyan);
                bmp.Save(filePath);
            }
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}

