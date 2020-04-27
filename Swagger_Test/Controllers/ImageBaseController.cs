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

        private string FixBase64ForImage(string Image) {
            var sbText = new System.Text.StringBuilder(Image,Image.Length);
            sbText.Replace("\r\n", String.Empty);
            sbText.Replace(" ", String.Empty);
            sbText.Replace("data:image/jpeg;base64,", String.Empty);
            return sbText.ToString();
        }

        internal StreamContent ImageStream(string data)
        {
            Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(data));
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));

            var memStream = new MemoryStream();
            bitImage.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }

        internal StreamContent ImageStream(Color color1, Color color2, int width=250, int height=50)
        {
            var rnd = new Random();
            var bmp = new Bitmap(width, height);
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

        internal int checkIfBelongsToMandelbrotSet(int x, int y, int iterations) {
            var realComponentOfResult = x;
            var imaginaryComponentOfResult = y;
            
            for (int i = 0; i < iterations; i++) {
                var tempRealComponent = realComponentOfResult * realComponentOfResult - imaginaryComponentOfResult * imaginaryComponentOfResult + x;
                var tempImaginaryComponent = realComponentOfResult * imaginaryComponentOfResult + y;
                realComponentOfResult = tempRealComponent;
                imaginaryComponentOfResult = tempImaginaryComponent;
                // Return a number as a percentage
                if (realComponentOfResult * imaginaryComponentOfResult > 5) {
                    return (int)(i / iterations * 100);
                }
            }
            return 0;
        }

        internal StreamContent MandelbrotImageStream(int width, int height, int zoom, int iterations)
        {
            var bmp = new Bitmap(width, height);
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    var belongsToSet = checkIfBelongsToMandelbrotSet(x / zoom - 1, y / zoom - 1, iterations);
                    if (belongsToSet > 0) {
                        bmp.SetPixel(x, y, Color.FromArgb(0, belongsToSet*2, 0));
                    }
                }
            }
            var memStream = new MemoryStream();
            bmp.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }
    }
}
