using Swagger.Net.Annotations;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Swagger_Test.Controllers
{
    public class FractalController : ImageBaseController
    {
        // GET: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Get(int width = 800, int height = 800, int zoom = 5000, int iterations = 32)
        {
            var response = new HttpResponseMessage();
            var sTime = DateTime.Now;
            response.Content = MandelbrotImageStream(width, height, zoom, iterations);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            response.Content.Headers.Add("render-speed", sTime.Diff());
            return response;
        }
    }

    public static class DateTimeExtension
    {
        public static string Diff(this DateTime value)
        {
            return (DateTime.Now - value).TotalMilliseconds.ToString();
        }
    }
}
