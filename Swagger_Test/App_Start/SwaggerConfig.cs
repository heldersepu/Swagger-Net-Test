using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Yaml.Serialization;
using System.Collections.Generic;

using Swagger_Test;
using Swagger_Test.Models;
using Swagger.Net.Application;
using Swagger.Net;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Swagger_Test
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        // By default, the service root url is inferred from the request used to access the docs.
                        // However, there may be situations (e.g. proxy and load-balanced environments) where this does not
                        // resolve correctly. You can workaround this by providing your own code to determine the root URL.
                        //
                        //c.RootUrl(req => GetRootUrlFromAppConfig());

                        // If schemes are not explicitly provided in a Swagger 2.0 document, then the scheme used to access
                        // the docs is taken as the default. If your API supports multiple schemes and you want to be explicit
                        // about them, you can use the "Schemes" option as shown below.
                        //
                        //c.Schemes(new[] { "http", "https" });

                        // Use "SingleApiVersion" to describe a single version API. Swagger 2.0 includes an "Info" object to
                        // hold additional metadata for an API. Version and title are required but you can also provide
                        // additional fields by chaining methods off SingleApiVersion.
                        //
                        c.SingleApiVersion("v1", "Swagger_Test");

                        // Taking to long to load the swagger docs? Enable this option to start caching it
                        //
                        //c.AllowCachingSwaggerDoc();

                        // If you want the output Swagger docs to be indented properly, enable the "PrettyPrint" option.
                        //
                        //c.PrettyPrint();

                        // If your API has multiple versions, use "MultipleApiVersions" instead of "SingleApiVersion".
                        // In this case, you must provide a lambda that tells Swagger-Net which actions should be
                        // included in the docs for a given API version. Like "SingleApiVersion", each call to "Version"
                        // returns an "Info" builder so you can provide additional metadata per API version.
                        //
                        //c.MultipleApiVersions(
                        //    (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                        //    (vc) =>
                        //    {
                        //        vc.Version("v2", "Swagger-Net Dummy API V2");
                        //        vc.Version("v1", "Swagger-Net Dummy API V1");
                        //    });

                        // You can use "BasicAuth", "ApiKey" or "OAuth2" options to describe security schemes for the API.
                        // See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md for more details.
                        // NOTE: These only define the schemes and need to be coupled with a corresponding "security" property
                        // at the document or operation level to indicate which schemes are required for an operation. To do this,
                        // you'll need to implement a custom IDocumentFilter and/or IOperationFilter to set these properties
                        // according to your specific authorization implementation
                        //
                        //c.BasicAuth("basic")
                        //    .Description("Basic HTTP Authentication");
                        //
                        //c.ApiKey("apiKey", "API Key Authentication", "header", typeof(KeyAuthorizeAttribute));
                        //
                        c.OAuth2("oauth2")
                            .Description("OAuth2 Implicit Grant")
                            .Flow("accessCode")
                            .AuthorizationUrl("http://www.facebook.com/dialog/oauth/?client_id=183620338840937&redirect_uri=http%3A%2F%2Fswashbuckletest.azurewebsites.net%2Fswagger")
                            .TokenUrl("https://graph.facebook.com/oauth/access_token?client_id=183620338840937&redirect_uri=http%3A%2F%2Fswashbuckletest.azurewebsites.net%2Fswagger&client_secret=de81460e907d213dcc4271aa7b1ae88a&grant_type=client_credentials");
                        //    .Scopes(scopes =>
                        //    {
                        //        scopes.Add("read", "Read access to protected resources");
                        //        scopes.Add("write", "Write access to protected resources");
                        //    });

                        // Set this flag to omit descriptions for any actions decorated with the Obsolete attribute
                        //c.IgnoreObsoleteActions();

                        // Comment this setting to disable Access-Control-Allow-Origin
                        c.AccessControlAllowOrigin("*");

                        // Each operation be assigned one or more tags which are then used by consumers for various reasons.
                        // For example, the swagger-ui groups operations according to the first tag of each operation.
                        // By default, this will be controller name but you can use the "GroupActionsBy" option to
                        // override with any value.
                        //
                        //c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());

                        // You can also specify a custom sort order for groups (as defined by "GroupActionsBy") to dictate
                        // the order in which operations are listed. For example, if the default grouping is in place
                        // (controller name) and you specify a descending alphabetic sort order, then actions from a
                        // ProductsController will be listed before those from a CustomersController. This is typically
                        // used to customize the order of groupings in the swagger-ui.
                        //
                        //c.OrderActionGroupsBy(new DescendingAlphabeticComparer());

                        // If you annotate Controllers and API Types with Xml comments:
                        // http://msdn.microsoft.com/en-us/library/b2s063f7(v=vs.110).aspx
                        // those comments will be incorporated into the generated docs and UI.
                        // Just make sure your comment file(s) have extension .XML
                        // You can add individual files by providing the path to one or
                        // more Xml comment files.
                        //
                        //c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + "file.ext");
                        c.IncludeAllXmlComments(thisAssembly, AppDomain.CurrentDomain.BaseDirectory);

                        // Swagger-Net makes a best attempt at generating Swagger compliant JSON schemas for the various types
                        // exposed in your API. However, there may be occasions when more control of the output is needed.
                        // This is supported through the "MapType" and "SchemaFilter" options:
                        //
                        // Use the "MapType" option to override the Schema generation for a specific type.
                        // It should be noted that the resulting Schema will be placed "inline" for any applicable Operations.
                        // While Swagger 2.0 supports inline definitions for "all" Schema types, the swagger-ui tool does not.
                        // It expects "complex" Schemas to be defined separately and referenced. For this reason, you should only
                        // use the "MapType" option when the resulting Schema is a primitive or array type. If you need to alter a
                        // complex Schema, use a Schema filter.
                        //
                        //c.MapType<ProductType>(() => new Schema { type = "integer", format = "int32" });

                        // If you want to post-modify "complex" Schemas once they've been generated, across the board or for a
                        // specific type, you can wire up one or more Schema filters.
                        //
                        c.SchemaFilter<ApplySchemaVendorExtensions>();

                        // In a Swagger 2.0 document, complex types are typically declared globally and referenced by unique
                        // Schema Id. By default, Swagger-Net does NOT use the full type name in Schema Ids. In most cases, this
                        // works well because it prevents the "implementation detail" of type namespaces from leaking into your
                        // Swagger docs and UI. However, if you have multiple types in your API with the same class name, you'll
                        // need to opt out of this behavior to avoid Schema Id conflicts.
                        //
                        //c.UseFullTypeNameInSchemaIds();

                        // Alternatively, you can provide your own custom strategy for inferring SchemaId's for
                        // describing "complex" types in your API.
                        //
                        //c.SchemaId(t => t.FullName.Contains('`') ? t.FullName.Substring(0, t.FullName.IndexOf('`')) : t.FullName);

                        // Set this flag to omit schema property descriptions for any type properties decorated with the
                        // Obsolete attribute
                        //c.IgnoreObsoleteProperties();

                        // In accordance with the built in JsonSerializer, Swagger-Net will, by default, describe enums as integers.
                        // You can change the serializer behavior by configuring the StringToEnumConverter globally or for a given
                        // enum type. Swagger-Net will honor this change out-of-the-box. However, if you use a different
                        // approach to serialize enums as strings, you can also force Swagger-Net to describe them as strings.
                        //
                        c.DescribeAllEnumsAsStrings();

                        // Similar to Schema filters, Swagger-Net also supports Operation and Document filters:
                        //
                        // Post-modify Operation descriptions once they've been generated by wiring up one or more
                        // Operation filters.
                        //
                        //c.OperationFilter<AddDefaultResponse>();
                        //
                        // If you've defined an OAuth2 flow as described above, you could use a custom filter
                        // to inspect some attribute on each action and infer which (if any) OAuth2 scopes are required
                        // to execute the operation
                        //
                        c.OperationFilter<AssignOAuth2SecurityRequirements>();
                        c.OperationFilter<AddRequiredHeaderParameters>();

                        // Post-modify the entire Swagger document by wiring up one or more Document filters.
                        // This gives full control to modify the final SwaggerDocument. You should have a good understanding of
                        // the Swagger 2.0 spec. - https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md
                        // before using this option.
                        //
                        c.DocumentFilter<YamlDocumentFilter>();
                        c.DocumentFilter<TestDocumentFilter>();
                        c.DocumentFilter<DocumentFilterAddFakes>();
                        c.DocumentFilter<SortModelDocumentFilter>();
                        c.DocumentFilter<ApplyDocumentFilter_ChangeCompany>();
                        c.DocumentFilter<AddImageResponseDocumentFilter>();
                        c.DocumentFilter<OptionalPathParamDocumentFilter>();

                        // In contrast to WebApi, Swagger 2.0 does not include the query string component when mapping a URL
                        // to an action. As a result, Swagger-Net will raise an exception if it encounters multiple actions
                        // with the same path (sans query string) and HTTP method. You can workaround this by providing a
                        // custom strategy to pick a winner or merge the descriptions for the purposes of the Swagger docs
                        //
                        //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                        // Wrap the default SwaggerGenerator with additional behavior (e.g. caching) or provide an
                        // alternative implementation for ISwaggerProvider with the CustomProvider option.
                        //
                        //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                    })
                .EnableSwaggerUi(c =>
                    {
                        // Use the "DocumentTitle" option to change the Document title.
                        // Very helpful when you have multiple Swagger pages open, to tell them apart.
                        //
                        c.DocumentTitle("Swagger_Test");

                        // Use the "InjectStylesheet" option to enrich the UI with one or more additional CSS stylesheets.
                        // The file must be included in your project as an "Embedded Resource", and then the resource's
                        // "Logical Name" is passed to the method as shown below.
                        //
                        c.InjectStylesheet(thisAssembly, "Swagger_Test.Styles.css");

                        // Use the "InjectJavaScript" option to invoke one or more custom JavaScripts after the swagger-ui
                        // has loaded. The file must be included in your project as an "Embedded Resource", and then the resource's
                        // "Logical Name" is passed to the method as shown above.
                        //
                        c.InjectJavaScript(thisAssembly, "Swagger_Test.custom.js");

                        // The swagger-ui renders boolean data types as a dropdown. By default, it provides "true" and "false"
                        // strings as the possible choices. You can use this option to change these to something else,
                        // for example 0 and 1.
                        //
                        //c.BooleanValues(new[] { "0", "1" });

                        // By default, swagger-ui will validate specs against swagger.io's online validator and display the result
                        // in a badge at the bottom of the page. Use these options to set a different validator URL or to disable the
                        // feature entirely.
                        //c.SetValidatorUrl("http://localhost/validator");
                        //c.DisableValidator();

                        // Use this option to control how the Operation listing is displayed.
                        // It can be set to "None" (default), "List" (shows operations for each resource),
                        // or "Full" (fully expanded: shows operations and their details).
                        //
                        c.DocExpansion(DocExpansion.List);

                        // Limit the number of operations shown to a smaller value
                        //
                        c.UImaxDisplayedTags(100);

                        // Filter the operations works as a search, to disable set to "null"
                        //
                        c.UIfilter("''");

                        // Specify which HTTP operations will have the 'Try it out!' option. An empty parameter list disables
                        // it for all operations.
                        //
                        //c.SupportedSubmitMethods("GET", "HEAD");

                        // Use the CustomAsset option to provide your own version of assets used in the swagger-ui.
                        // It's typically used to instruct Swagger-Net to return your version instead of the default
                        // when a request is made for "index.html". As with all custom content, the file must be included
                        // in your project as an "Embedded Resource", and then the resource's "Logical Name" is passed to
                        // the method as shown below.
                        //
                        c.CustomAsset("custom", thisAssembly, "Swagger_Test.custom.html");

                        // If your API has multiple versions and you've applied the MultipleApiVersions setting
                        // as described above, you can also enable a select box in the swagger-ui, that displays
                        // a discovery URL for each version. This provides a convenient way for users to browse documentation
                        // for different API versions.
                        //
                        //c.EnableDiscoveryUrlSelector();

                        // If your API supports the OAuth2 Implicit flow, and you've described it correctly, according to
                        // the Swagger 2.0 specification, you can enable UI support as shown below.
                        //
                        c.EnableOAuth2Support(
                            clientId: "183620338840937",
                            clientSecret: "de81460e907d213dcc4271aa7b1ae88a",
                            realm: "swaggertestapp",
                            appName: "swaggertestapp"
                        //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                        );
                    });
        }

    private class DocumentFilterAddFakes : IDocumentFilter
    {
        private PathItem FakePathItem(int i)
        {
            var x = new PathItem();
            x.get = new Operation()
            {
                tags = new[] { "Fake" },
                operationId = "Fake_Get" + i.ToString() ,
                consumes = null,
                produces = new[] { "application/json", "text/json", "application/xml", "text/xml" },
                parameters = new List<Parameter>()
                            {
                                new Parameter()
                                {
                                    name = "id",
                                    @in = "path",
                                    required = true,
                                    type = "integer",
                                    format = "int32",
                                    @default = 8
                                }
                            },
            };
            x.get.responses = new Dictionary<string, Response>();
            x.get.responses.Add("200", new Response() { description = "OK", schema = new Schema() { type = "string" } });
            return x;
        }

        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            for (int i = 0; i < 10; i++)
            {
                swaggerDoc.paths.Add("/Fake/" + i  + "/{id}", FakePathItem(i));
            }
        }
    }

        private class YamlDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                string file = AppDomain.CurrentDomain.BaseDirectory + "swagger_yaml.txt";
                if (!File.Exists(file))
                {
                    var serializer = new YamlSerializer();
                    serializer.SerializeToFile(file, swaggerDoc);
                }
            }
        }

        private class OptionalPathParamDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                string actionPath = "/attrib/{payId}";
                swaggerDoc.paths[actionPath].get.parameters[0].required = false;
            }
        }

        private class SortModelDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                string model = "ViewModelTest";
                var props = swaggerDoc.definitions[model].properties.OrderBy(x => x.Key).ToArray();
                swaggerDoc.definitions[model].properties.Clear();
                foreach (var prop in props)
                {
                    swaggerDoc.definitions[model].properties.Add(prop.Key, prop.Value);
                }
            }
        }

        private class TestDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                swaggerDoc.info.description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia.";
                foreach (var path in swaggerDoc.paths)
                {
                    if (path.Key.Contains("foo") && path.Value.get != null)
                    {
                        path.Value.put = path.Value.get;
                    }
                }
            }
        }

        private class AddImageResponseDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                swaggerDoc.paths["/api/PngImage"].post.produces.Clear();
                swaggerDoc.paths["/api/PngImage"].post.produces.Add("image/png");
            }
        }

        public class AddRequiredHeaderParameters : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();

                if (operation.operationId == "ValueProvider_Put")
                {
                    operation.parameters.Add(HeaderParam("CID", "101"));
                    operation.parameters.Add(HeaderParam("QID", "102"));
                }
                else if (operation.tags[0].Equals("FooBar"))
                {
                    // add other header parameters here
                }
            }

            public Parameter HeaderParam(string name, string defaultValue, bool required = true, string type = "", string description = "")
            {
                return new Parameter
                {
                    name = name,
                    @in = "header",
                    @default = defaultValue,
                    type = type,
                    description = description,
                    required = required
                };
            }
        }

        private class ApplyDocumentFilter_ChangeCompany : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                if (swaggerDoc.definitions != null)
                {
                    swaggerDoc.definitions.Add("Company123", swaggerDoc.definitions["Company"]);
                }
                if (swaggerDoc.paths != null)
                {
                    swaggerDoc.paths["/api/Company"].get.responses["200"].schema.@ref = "#/definitions/Company123";
                }
            }
        }

        public static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return (apiDesc.Route.RouteTemplate.ToLower().Contains(targetApiVersion.ToLower()));
        }

        private class ApplyDocumentVendorExtensions : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                schemaRegistry.GetOrRegister(typeof(ExtraType));
                //schemaRegistry.GetOrRegister(typeof(BigClass));

                var paths = new Dictionary<string, PathItem>(swaggerDoc.paths);
                swaggerDoc.paths.Clear();
                foreach (var path in paths)
                {
                    if (path.Key.Contains("foo"))
                        swaggerDoc.paths.Add(path);
                }
            }
        }

        private class ApplySchemaVendorExtensions : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
            {
                // Modify the example values in the final SwaggerDocument
                //
                if (schema.properties != null)
                {
                    foreach (var p in schema.properties)
                    {
                        switch (p.Value.format)
                        {
                            case "uuid":
                                p.Value.example = Guid.NewGuid();
                                break;
                            case "int32":
                                p.Value.example = 123;
                                break;
                            case "double":
                                p.Value.example = 9858.216;
                                break;
                            default:
                                switch (p.Key)
                                {
                                    case "index":
                                        p.Value.example = new Dictionary<int, string>
                                            { { 1, "abc" }, { 2, "def" } };
                                        break;
                                    case "keys":
                                        p.Value.example = new List<string>
                                            { "abc", "def", "ghi" };
                                        break;
                                    case "xyz":
                                        p.Value.example = "abcasdfasd";
                                        p.Value.maxLength = 10;
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
        }

        public class AssignOAuth2SecurityRequirements : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                var actFilters = apiDescription.ActionDescriptor.GetFilterPipeline();
                if (actFilters.Select(f => f.Instance).OfType<AllowAnonymousAttribute>().Any())
                    return; // must be an anonymous method

                if (operation.security == null)
                    operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
                {
                    {"oauth2", new List<string> {}}
                };
                operation.security.Add(oAuthRequirements);
            }
        }
    }
}
