using ThiagoToDo.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThiagoToDo.Services.Interfaces
{
    public interface IToDoService : IDisposable
    {
        Task<ToDoDTO> CreateToDoAsync(ToDoDTO dto);

        Task<IEnumerable<ToDoDTO>> GetToDoItemsAsync();

        Task<ToDoDTO> ChangeTodoAsync(ToDoDTO dto);

        Task DeleteTodoAsync(int id);

    }
}
