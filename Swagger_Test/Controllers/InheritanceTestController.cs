using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public abstract class Feature
    {
        /// <summary>We all need a Title</summary>
        public string Title { get; set; }
    }

    public class ImageFeature : Feature
    {
        /// <summary>Here goes your image URL</summary>
        public string ImageUrl { get; set; }
    }

    public class InheritanceTestController : ApiController
    {
        public ImageFeature Get([FromUri]ImageFeature imageFeature)
        {
            return imageFeature;
        }

        public ImageFeature Post(ImageFeature imageFeature)
        {
            return imageFeature;
        }
    }
}
