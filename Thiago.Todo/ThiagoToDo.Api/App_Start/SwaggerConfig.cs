using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using ThiagoToDo.Api;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ThiagoToDo.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "ToDoApi");
                    c.ApiKey("apiKey")
                        .Description("API Key Authentication")
                        .Name("X-ApiKey")
                        .In("header");

                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("X-ApiKey", "header");
                });
        }
    }
}
