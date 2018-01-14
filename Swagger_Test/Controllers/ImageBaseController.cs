using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class ImageBaseController : ApiController
    {
        private static Random rnd = new Random();

        internal Color RandomColor
        {
            get
            {
                return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
        }

        internal StreamContent ImageStream(Color color1, Color color2)
        {
            var rnd = new Random();
            var bmp = new Bitmap(250, 50);
            for (int y = 0; y < bmp.Height; ++y)
            {
                int num = rnd.Next(1, 20);
                for (int x = 0; x < bmp.Width; ++x)
                    bmp.SetPixel(x, y, (x % num == 0) ? color1 : color2);
            }
            var memStream = new MemoryStream();
            bmp.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }
    }
}

