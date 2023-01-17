using ThiagoToDo.Api.Contracts.Reponse;
using System.Net;

using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Filters;
using NLog;
using WebGrease.Css.Ast;

namespace ThiagoToDo.Api.Filters
{
    //TODO: Not Working
    public class ApiErrorFilterAttribute : ExceptionFilterAttribute
    {
        
        public ApiErrorFilterAttribute() {
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception !=null)
            {
                actionExecutedContext.Response = new ErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception);

                LogManager.GetLogger("").Error(actionExecutedContext.Exception);
            }

           

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
       
    }

}
