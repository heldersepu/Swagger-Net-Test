using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class ImageBaseController : ApiController
    {
        private string FilePath(string fileName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        internal StreamContent ImageStream(string name, Color color1, Color color2)
        {
            string filePath = FilePath(name);
            if (!File.Exists(filePath))
            {
                var bmp = new Bitmap(250, 50);
                for (int y = 0; y < bmp.Height; ++y)
                    for (int x = 0; x < bmp.Width; ++x)
                        bmp.SetPixel(x, y, (x % 5 == 0) ? color1 : color2);
                bmp.Save(filePath);
            }
            return new StreamContent(new FileStream(filePath, FileMode.Open)); ;
        }
    }
}

