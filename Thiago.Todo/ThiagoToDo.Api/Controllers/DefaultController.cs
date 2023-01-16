using ThiagoToDo.Services.Interfaces;
using ThiagoToDo.Services.DTOs;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using ThiagoToDo.Api.Contracts.Requests;
using AutoMapper;
using Unity;
using ThiagoToDo.Api.Filters;
using System;

namespace ThiagoToDo.Api.Controllers
{
	[RoutePrefix("/")]
	public class DefaultController : ApiController
	{
		
		/// <summary>
		/// Api is ready 
		/// </summary>
		/// <param name="toDo"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IHttpActionResult> Index([FromBody] ToDo toDo) =>
             Ok("ToDo Api is ready!");
    }
}
