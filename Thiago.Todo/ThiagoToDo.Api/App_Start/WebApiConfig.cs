using ThiagoToDo.Services.Mapping;
using System.Web.Http;
using ThiagoToDo.Api.Mapping;
using AutoMapper;
using ThiagoToDo.Api.Filters;
using ThiagoToDo.Api.Handlers;

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
