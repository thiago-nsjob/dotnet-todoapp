using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ThiagoToDo.Api
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapHttpRoute(
                name: "ToDoApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Default", action = "Index",id = RouteParameter.Optional }
            );
        }
	}
}
