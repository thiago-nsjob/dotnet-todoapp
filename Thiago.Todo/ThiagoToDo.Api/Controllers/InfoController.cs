
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;


namespace ThiagoToDo.Api.Controllers
{
	[AllowAnonymous]
	public class InfoController : ApiController
	{

		/// <summary>
		/// Api info 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		public async Task<IHttpActionResult> Index() =>
			 Ok(new { 
				Status="Healthy",
				Version= ConfigurationManager.AppSettings["AppVersion"]
             });
       

    }
}
