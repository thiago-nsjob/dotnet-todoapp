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
	[RoutePrefix("ToDos")]
	[ApiErrorFilterAttribute]
	public class ToDoController : ApiController
	{
		private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        public ToDoController(IToDoService toDoService, IMapper mapper)
		{
            _toDoService = toDoService;
            _mapper = mapper;
        }

		
		/// <summary>
		/// An HTTP Post request to create a new to do item
		/// </summary>
		/// <param name="toDo"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IHttpActionResult> CreateToDo([FromBody] ToDo toDo)
		{
            throw new Exception("Something went wrong");
            return Ok(await _toDoService.CreateToDoAsync(_mapper.Map<ToDoDTO>(toDo)));
	
		}

		/// <summary>
		/// An HTTP Get request to retrieve all of the to do items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IHttpActionResult> GetToDos()
		{
            return Ok(await _toDoService.GetToDoItemsAsync());
		}

        /// <summary>
        /// An HTTP Get request to retrieve all of the to do items
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateToDos()
        {
            return Ok(await _toDoService.GetToDoItemsAsync());
          
        }

        /// <summary>
        /// An HTTP Get request to retrieve all of the to do items
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteToDo([FromUri] int id)
        {
           return Ok(await _toDoService.GetToDoItemsAsync());   
        }

    }
}
