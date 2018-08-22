using Swagger.Net.Annotations;
using System;
using System.Drawing;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Runtime.Caching;

namespace Swagger_Test.Controllers
{
    public class ImageController : ImageBaseController
    {
        // GET: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            var memCache = MemoryCache.Default.Get("image_data");
            if (memCache == null)
                response.Content = ImageStream(Color.Red, Color.Cyan);
            else
                response.Content = ImageStream((string)memCache);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // POST: api/Image
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Post(ImageData img)
        {
            var response = new HttpResponseMessage();
            if (img == null || string.IsNullOrEmpty(img.Data) || !img.Data.StartsWith("data"))
                response.Content = ImageStream(Color.White, Color.Blue);
            else
            {
                response.Content = ImageStream(img.Data);
                var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(2) };
                MemoryCache.Default.Add("image_data", img.Data, policy);
            }

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        // PUT: api/Image
        [SwaggerResponse(200, "Download an image", mediaType: "application/octet-stream")]
        public HttpResponseMessage Put()
        {
            var response = new HttpResponseMessage();
            var c = RandomColor;
            response.Content = ImageStream(Color.White, c);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment") { FileName = $"image_{c.R}_{c.G}_{c.B}.png" };
            return response;
        }

        // PATCH: api/Image
        [SwaggerResponse(200, "image.svg", mediaType: "image/svg")]
        public HttpResponseMessage Patch()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(
                "<svg><circle cx='50' cy='50' r='40' fill='red' /></svg>",
                Encoding.UTF8, "text/html"
            );
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/svg");
            return response;
        }
    }

    public class ImageData
    {
        public string Data { get; set; }
    }
}
