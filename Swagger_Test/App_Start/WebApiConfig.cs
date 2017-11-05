using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace Swagger_Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.AddApiVersioning(options => {
            //    options.ReportApiVersions = true;
            //});

            //var constraintResolver = new System.Web.Http.Routing.DefaultInlineConstraintResolver();
            //constraintResolver.ConstraintMap.Add("apiVersion", typeof(ApiVersionRouteConstraint));
            //config.MapHttpAttributeRoutes(constraintResolver);

            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Formatters.Clear();
            config.Formatters.Add(new BrowserJsonFormatter());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.ParameterBindingRules.Insert(0, GetCustomParameterBinding);
            TypeDescriptor.AddAttributes(typeof(NodaTime.LocalDate), new TypeConverterAttribute(typeof(ObjectIdConverter)));
        }

        public static HttpParameterBinding GetCustomParameterBinding(HttpParameterDescriptor descriptor)
        {
            if (descriptor.ParameterType == typeof(NodaTime.LocalDate))
            {
                return new ObjectIdParameterBinding(descriptor);
            }
            // any other types, let the default parameter binding handle
            return null;
        }

        private class ObjectIdParameterBinding : HttpParameterBinding, IValueProviderParameterBinding
        {
            public ObjectIdParameterBinding(HttpParameterDescriptor desc) : base(desc) { }

            public override Task ExecuteBindingAsync(ModelMetadataProvider m, HttpActionContext a, CancellationToken c)
            {
                SetValue(a, (NodaTime.LocalDate)a.ControllerContext.RouteData.Values[Descriptor.ParameterName]);
                return Task.CompletedTask;
            }

            public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; } = new[] { new QueryStringValueProviderFactory() };
        }

        private class ObjectIdConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return (sourceType == typeof(string)) ? true : base.CanConvertFrom(context, sourceType);
            }
        }

        private class BrowserJsonFormatter : JsonMediaTypeFormatter
        {
            public BrowserJsonFormatter()
            {
                this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                this.SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include
                };
            }

            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
    }
}
