using Newtonsoft.Json;
using System.Text;
using System.Web.Http;

namespace Swagger_Test.Controllers
{
    public class NestedSwagController : ApiController
    {
        // GET: api/NestedSwag/5
        public IHttpActionResult Get(int id)
        {
            var swag = new StringBuilder();
            swag.Append("{\"swagger\":\"2.0\",\"info\":{\"version\":\"V1\",\"title\":\"Test\"},\"host\":\"swagger-net-test.azurewebsites.net\",\"schemes\":[\"http\"],");
            swag.Append("\"paths\":{\"/api/test\":{\"get\":{\"operationId\":\"test_Get\",\"consumes\":[],\"produces\":[\"application/json\"],\"parameters\":[],\"responses\":{\"200\":{\"description\":\"OK\",\"schema\":{\"$ref\":\"#/definitions/Test0\"}}}}}},");
            swag.Append("\"definitions\":{\"Location\":{\"properties\":{\"Lat\":{\"type\":\"number\",\"format\":\"float\"},\"Lon\":{\"type\":\"number\",\"format\":\"float\"}},\"xml\":{\"name\":\"Location\"}},");
            for (int x = 0; x < id; x++)
            {
                swag.AppendDef(x, "Test" + (x + 1).ToString());
                swag.Append(",");
            }
            swag.AppendDef(id, "Location");
            swag.Append("}}");
            return Ok(JsonConvert.DeserializeObject(swag.ToString()));
        }
    }

    public static class StringBuilderExt
    {
        public static void AppendDef(this StringBuilder swag, int x, string def)
        {
            swag.Append("\"Test" + x.ToString() + "\":{\"properties\":{");
            for (int i = 0; i < 5; i++)
                swag.Append("\"val" + i.ToString() + "\":{\"$ref\":\"#/definitions/" + def + "\"},");
            swag.Append("\"val\":{\"$ref\":\"#/definitions/Location\"}");
            swag.Append("},\"xml\":{\"name\":\"Test" + x.ToString() + "\"},\"type\":\"object\"}");
        }
    }
}
