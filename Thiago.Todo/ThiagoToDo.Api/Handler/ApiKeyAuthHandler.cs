using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.Configuration;

//Based on
//https://blog.maartenballiauw.be/post/2012/10/18/from-api-key-to-user-with-aspnet-web-api.html
//https://www.c-sharpcorner.com/article/asp-net-mvc5-rest-web-api-authorization/

namespace ThiagoToDo.Api.Handlers
{
    public class ApiKeyAuthHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> apiKeyHeaderValues = null;

            var serverKey = WebConfigurationManager.AppSettings["ApiKey"];

            //Ideally this should be an asymetric key or a oauth token
            if (request.Headers.TryGetValues("X-ApiKey", out apiKeyHeaderValues) 
                && apiKeyHeaderValues.First() == serverKey)  
            {

                var usernameClaim = new Claim(ClaimTypes.Name, "AllowedUser");
                var identity = new ClaimsIdentity(new[] { usernameClaim }, "ApiKey");
                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                if (HttpContext.Current != null)
                    HttpContext.Current.User = principal;
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}