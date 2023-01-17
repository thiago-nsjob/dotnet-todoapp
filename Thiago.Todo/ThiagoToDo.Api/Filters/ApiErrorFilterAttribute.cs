using ThiagoToDo.Api.Contracts.Reponse;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Mvc;
using System.Web.Http.Results;
using System.Web.Http.Filters;

namespace ThiagoToDo.Api.Filters
{
    //TODO: Not Working
    public class ApiErrorFilterAttribute : ExceptionFilterAttribute
    {
        
        public ApiErrorFilterAttribute() {
        }

        public void OnException(ExceptionContext filterContext)
        {
    
            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new JsonResult() { Data = new ErrorResponse(HttpStatusCode.BadRequest, "9999", filterContext.Exception.Message) }; 
                filterContext.ExceptionHandled = true;
            }
            
        }
    }

}
