
using System.Web.Http;
using ThiagoToDo.Api.Filters;

namespace ThiagoToDo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ApiErrorFilterAttribute());
            config.MapHttpAttributeRoutes();
        }
    }
}
