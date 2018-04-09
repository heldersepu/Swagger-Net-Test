using Newtonsoft.Json;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class BigSwagController : ApiController
    {
        // GET: api/BigSwag/5
        public IHttpActionResult Get(int id)
        {
            var swag = new StringBuilder();
            swag.Append("{\"swagger\":\"2.0\",\"info\":{\"version\":\"V1\",\"title\":\"Test\"},\"host\":\"swagger-net-test.azurewebsites.net\",\"schemes\":[\"http\"],");
            swag.Append("\"paths\":{\"/api/test\":{\"get\":{\"operationId\":\"test_Get\",\"consumes\":[],\"produces\":[\"application/json\"],\"parameters\":[],\"responses\":{\"200\":{\"description\":\"OK\",\"schema\":{\"$ref\":\"#/definitions/Test1K\"}}}}}},");
            swag.Append("\"definitions\":{\"Location\":{\"properties\":{\"Lat\":{\"type\":\"number\",\"format\":\"float\"},\"Lon\":{\"type\":\"number\",\"format\":\"float\"}},\"xml\":{\"name\":\"Location\"}},\"Test1K\":{\"properties\":{");
            for (int i = 0; i < id; i++)
                swag.Append("\"val"+ i.ToString() + "\":{\"$ref\":\"#/definitions/Location\"},");
            swag.Append("\"val\":{\"$ref\":\"#/definitions/Location\"}");
            swag.Append("},\"xml\":{\"name\":\"Test1K\"},\"type\":\"object\"}}}");
            return Ok(JsonConvert.DeserializeObject(swag.ToString()));
        }
    }
}
