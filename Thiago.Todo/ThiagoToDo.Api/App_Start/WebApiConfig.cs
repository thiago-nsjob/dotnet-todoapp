using ThiagoToDo.Services.Mapping;
using System.Web.Http;
using ThiagoToDo.Api.Mapping;
using AutoMapper;

namespace ThiagoToDo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
      
            //Mapper.Initialize(cfg => {
            //    cfg.AddServiceProfiler();
            //    cfg.AddApiProfiler();
            //});

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
