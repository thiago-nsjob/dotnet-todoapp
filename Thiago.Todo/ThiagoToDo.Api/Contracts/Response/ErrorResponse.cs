
using System.Net;
using System.Net.Http;

namespace ThiagoToDo.Api.Contracts.Reponse
{

    public class ErrorResponse: HttpResponseMessage
    {
        public ErrorResponse(HttpStatusCode statusCode, string errorCode, string message) : base(statusCode)
        {
            ErrorCode  = errorCode;
            Message = message;  
        }

        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}