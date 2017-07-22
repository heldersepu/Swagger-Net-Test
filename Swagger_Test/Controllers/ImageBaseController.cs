using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class ImageBaseController : ApiController
    {
        internal StreamContent ImageStream(Color color1, Color color2)
        {
            var bmp = new Bitmap(250, 50);
            for (int y = 0; y < bmp.Height; ++y)
                for (int x = 0; x < bmp.Width; ++x)
                    bmp.SetPixel(x, y, (x % 5 == 0) ? color1 : color2);
            var memStream = new MemoryStream();
            bmp.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }
    }
}

