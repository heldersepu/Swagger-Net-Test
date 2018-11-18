//using Swagger.Net.Annotations;
using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class PngImageController : ImageBaseController
    {
        // POST: api/PngImage
        [SwaggerForm("ImportImage", "Upload image file")]
        public HttpResponseMessage Post()
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.Red, Color.Blue);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        [HttpPost, Route("api/upc-a")]
        //[SwaggerResponse(HttpStatusCode.InternalServerError, "Empty UPC code.")]
        //[SwaggerResponse(HttpStatusCode.ExpectationFailed, "Invalid UPC code.")]
        //[SwaggerResponse(HttpStatusCode.OK, "Image in image/png format", mediaType: "image/png")]
        public HttpResponseMessage UPCA([FromBody]string value)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Empty UPC code.");
            }
            else if(value.Length < 10)
            {
                response.StatusCode = HttpStatusCode.ExpectationFailed;
                response.Content = new StringContent("Invalid UPC code.");
            }
            else
            {
                response.Content = ImageStream(RandomColor, RandomColor);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            }
            return response;
        }
    }
}
