using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Swagger_Test
{
    [RoutePrefix("api/Random")]
    public class RandomController : ApiController
    {
        private static Random rnd = new Random();

        internal Color RandomColor
        {
            get
            {
                return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
        }

        [Route("GetRandomColor")]
        [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
        public Color GetRandomColor()
        {
            return RandomColor;
        }

        [Route("GetRandomNumber")]
        [CacheOutput(ClientTimeSpan = 10, ServerTimeSpan = 10)]
        public int GetRandomNumber(int max)
        {
            return rnd.Next(max);
        }
    }
}
