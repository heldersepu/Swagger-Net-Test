using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Swagger.Net.Application;
using Swagger_Test;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace UnitTests
{
    [TestClass()]
    public class SwaggerTests
    {
        private SwaggerDocsHandler Handler(Action<SwaggerDocsConfig> configure = null)
        {
            var swaggerDocsConfig = new SwaggerDocsConfig();
            configure?.Invoke(swaggerDocsConfig);
            return new SwaggerDocsHandler(swaggerDocsConfig);
        }

        private HttpRequestMessage Request
        {
            get
            {
                var Configuration = new HttpConfiguration();
                var request = new HttpRequestMessage(HttpMethod.Get, "http://tempuri.org/swagger/docs/v1");
                request.Properties[HttpPropertyKeys.HttpConfigurationKey] = Configuration;

                string routeTemplate = "swagger/docs/{apiVersion}";
                var route = new HttpRoute(routeTemplate);
                var routeData = route.GetRouteData("/", request) ?? new HttpRouteData(route);

                request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
                return request;
            }
        }
         
        [TestMethod()]
        public void GenerateSwaggerJson()
        {           
            var handler = Handler(SwaggerConfig.SwaggerDocConf);
            var responseMessage =  new HttpMessageInvoker(handler)
                .SendAsync(Request, new CancellationToken(false)).Result;
            var responseContent = responseMessage.Content.ReadAsAsync<JObject>().Result;
            Assert.IsNotNull(responseContent);
            File.WriteAllText("swagger.json", responseContent.ToString());
        }
    }
}