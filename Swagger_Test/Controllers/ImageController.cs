using System;
using System.Drawing;
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

        private string FilePath(string fileName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        private void CreateImage(string filePath, Color color1, Color color2)
        {
            Bitmap bmp = new Bitmap(250, 50);
            for (int y = 0; y < bmp.Height; ++y)
                for (int x = 0; x < bmp.Width; ++x)
                    bmp.SetPixel(x, y, (x % 5 == 0) ? color1 : color2);
            bmp.Save(filePath);
        }
    }
}

