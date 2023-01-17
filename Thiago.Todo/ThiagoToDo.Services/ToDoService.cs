using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.Services.Interfaces;
using ThiagoToDo.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ThiagoToDo.DataAccessLayer.Entities;
using System.Data.Entity;
using NLog;
using ThiagoToDoApp.DataAccessLayer.Abstractions;

namespace ThiagoToDo.Services
{
	public class ToDoService : IToDoService
	{

		private readonly IRepository<ToDo> _repo;
		private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper _mapper;

        public ToDoService() { }

        public ToDoService(IRepository<ToDo> repo,IMapper mapper)
		{
            _repo = repo;
			_mapper = mapper;

        }

		/// <summary>
		/// Creates a new to do list item asynchronously and returns true if successful 
		/// </summary>
		/// <returns></returns>
		public async Task<ToDoDTO> CreateToDoAsync(ToDoDTO dto)
		{
			try
			{
				var toDo = _mapper.Map<ToDo>(dto);

                var newToDo = await _repo.InsertAsync(toDo);

                return _mapper.Map<ToDoDTO>(newToDo);
			}
			catch (Exception exception)
			{
				// Logs the error and throws the exception
				_logger.Error(exception);
				throw;
			}
		}

		/// <summary>
		/// Retrieves a collection of all of the current to do list items asynchronously
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<ToDoDTO>> GetToDoItemsAsync()
		{
			try
			{
				return Mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>(
					await _repo.GetAllAsync());
			}
			catch (Exception exception)
			{
				_logger.Error(exception);
				throw;
			}
		}


        /// <summary>
        /// Update a given todo with the informed parameters
        /// </summary>
        /// <returns></returns>
        public async Task<ToDoDTO> ChangeTodoAsync(ToDoDTO dto)
        {
            try
            {
				var changedTodo = await _repo.UpdateAsync(Mapper.Map<ToDo>(dto));
                return Mapper.Map<ToDoDTO>(changedTodo);
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                throw;
            }
        }

        /// <summary>
        /// Deletes a given todo with the informed parameters
        /// </summary>
        /// <returns></returns>
        public async Task DeleteTodoAsync(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
    
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                throw;
            }
        }

        public void Dispose()
		{
		
		}

	}
}
