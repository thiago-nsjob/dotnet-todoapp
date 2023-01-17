
using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using Newtonsoft.Json;


namespace ThiagoToDo.Api.Contracts.Reponse
{

    public class ErrorResponse: HttpResponseMessage
    {
        public ErrorResponse(HttpStatusCode statusCode,Exception ex) : base(statusCode)
        {
            Content = new StringContent(JsonConvert.SerializeObject(new {
                ErrorCode="SomeErroCode",
                Message = ex.Message,
                Type= ex.GetType().Name
            }), System.Text.Encoding.UTF8, "application/json");
        }
    }
}