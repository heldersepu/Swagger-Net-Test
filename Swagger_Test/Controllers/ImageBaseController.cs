using System;
using System.Drawing;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class ImageBaseController : ApiController
    {
        internal string FilePath(string fileName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        internal void CreateImage(string filePath, Color color1, Color color2)
        {
            Bitmap bmp = new Bitmap(250, 50);
            for (int y = 0; y < bmp.Height; ++y)
                for (int x = 0; x < bmp.Width; ++x)
                    bmp.SetPixel(x, y, (x % 5 == 0) ? color1 : color2);
            bmp.Save(filePath);
        }
    }
}

