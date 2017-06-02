using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public CategoryModel Parent { get; set; }
    }

    public class RecursiveParamController : ApiController
    {
        public int Post(CategoryModel value)
        {
            return 1;
        }
    }
}
