using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Swagger.Net.Application;
using Swagger_Test;
using System;
using System.IO;
using System.Linq;
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

        private HttpConfiguration Configuration
        {
            get
            {
                var config = new HttpConfiguration();
                var controllers = SwaggerConfig.ThisAssembly.GetTypes().Where(t => typeof(ApiController).IsAssignableFrom(t));
                foreach (var type in controllers)
                {
                    var controllerName = type.Name.ToLower().Replace("controller", String.Empty);
                    var route = new HttpRoute(
                        String.Format("{0}/{{id}}", controllerName),
                        new HttpRouteValueDictionary(new { controller = controllerName, id = RouteParameter.Optional }));
                    config.Routes.Add(controllerName, route);
                }
                return config;
            }
        }

        private HttpRequestMessage Request
        {
            get
            {
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