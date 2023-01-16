using ThiagoToDo.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThiagoToDo.Services.Interfaces
{
    public interface IToDoService : IDisposable
    {
        Task<bool> CreateToDoAsync(ToDoDTO toDoViewModel);

        Task<IEnumerable<ToDoDTO>> GetToDoItemsAsync();

    }
}
