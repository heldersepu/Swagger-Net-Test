using Swagger.Net.Annotations;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    [RoutePrefix("MapTiles")]
    public class MapTilesController : ImageBaseController
    {
        [Route("{z}/{x}/{y}")]
        [SwaggerResponse(200, mediaType: "image/png")]
        public HttpResponseMessage Get(int z, int x, int y)
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.White, Color.White, 256, 256);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}
