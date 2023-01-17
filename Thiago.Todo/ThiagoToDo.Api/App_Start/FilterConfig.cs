using System.Web;
using System.Web.Mvc;
using ThiagoToDo.Api.Filters;

namespace ThiagoToDo.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) =>
            filters.Add(new HandleErrorAttribute());
           
        
    }
}
