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

namespace ThiagoToDo.Services
{
	public class ToDoService : IToDoService
	{

		private readonly ToDoDbContext _dbContext;
		private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
		public ToDoService() { }
        public ToDoService(ToDoDbContext someonesToDoListContext)
		{
			_dbContext = someonesToDoListContext;
		}

		/// <summary>
		/// Creates a new to do list item asynchronously and returns true if successful 
		/// </summary>
		/// <returns></returns>
		public async Task<bool> CreateToDoAsync(ToDoDTO toDoDTO)
		{
			try
			{
				var toDo = Mapper.Map<ToDoDTO, ToDo>(toDoDTO);
	
				_dbContext.ToDos.Add(toDo);

				return true;
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
			
				return Mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoDTO>>
					(await _dbContext.ToDos.ToListAsync());
			}
			catch (Exception exception)
			{
				_logger.Error(exception);
				throw;
			}
		}

		public void Dispose()
		{
			_dbContext?.Dispose();
		}

	}
}
