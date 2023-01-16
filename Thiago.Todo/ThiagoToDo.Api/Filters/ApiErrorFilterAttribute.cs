using ThiagoToDo.Api.Contracts.Reponse;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Mvc;
using System.Web.Http.Results;

namespace ThiagoToDo.Api.Filters
{
    public class ApiErrorFilterAttribute : FilterAttribute, IExceptionFilter
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
