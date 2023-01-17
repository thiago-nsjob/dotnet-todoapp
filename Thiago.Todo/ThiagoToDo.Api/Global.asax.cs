
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ThiagoToDo.Api;
using ThiagoToDo.Api.Handlers;

namespace ThiagoToDo.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiKeyAuthHandler());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           ;  
        }
    }
}
