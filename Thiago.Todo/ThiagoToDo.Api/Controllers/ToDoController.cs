using ThiagoToDo.Services.Interfaces;
using ThiagoToDo.Services.DTOs;
using System.Threading.Tasks;
using System.Web.Http;
using NLog;
using ThiagoToDo.Api.Contracts;
using AutoMapper;
using Unity;
using ThiagoToDo.Api.Filters;
using System;
using ThiagoToDo.Api.Mapping;

namespace ThiagoToDo.Api.Controllers
{
    [Authorize(Users = "AllowedUser")]
    [ApiErrorFilterAttribute]
    [RoutePrefix("Todos")]
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
        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody] ToDo toDo)
		{
            var dto = await _toDoService.CreateToDoAsync(toDo.ToDTO());

            return Ok(dto.ToModel());
	
		}

		/// <summary>
		/// An HTTP Get request to retrieve all of the to do items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
		{
            return Ok(
                await _toDoService.GetToDoItemsAsync());
		}

        /// <summary>
        /// An HTTP PUT to modify a ToDo
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Put([FromBody] ToDo toDo)
        {
            return Ok(
                await _toDoService.ChangeTodoAsync(toDo.ToDTO()));
          
        }

        /// <summary>
        /// An HTTP Delete to wipe the informed TODO
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
           await _toDoService.DeleteTodoAsync(id);
           return Ok();   
        }

    }
}
