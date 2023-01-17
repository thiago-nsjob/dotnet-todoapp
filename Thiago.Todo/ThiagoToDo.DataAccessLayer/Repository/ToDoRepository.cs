using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDoApp.DataAccessLayer.Abstractions;

namespace ThiagoToDoApp.DataAccessLayer
{
    public class ToDoRepository: IRepository<ToDo>
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await GetByIdAsync(id);

            _dbContext.ToDos.Remove(todo);

            await SaveAsync();
        }

        //TODO:implement paging
        public async Task<IEnumerable<ToDo>> GetAllAsync() =>
             await _dbContext.ToDos.ToListAsync();
        
        public async Task<ToDo> GetByIdAsync(int id) =>
            await _dbContext.ToDos
                 .Where(item => item.Id == id)
                 .SingleOrDefaultAsync(); // If there is more than one, we want it to fail.

        public async Task<ToDo> InsertAsync(ToDo entity)
        {
            var newEntity = _dbContext.ToDos.Add(entity);

            await _dbContext.SaveChangesAsync();

            return newEntity;
        }
       
        public async Task<ToDo> UpdateAsync(ToDo entity)
        {
            var todo = await GetByIdAsync(entity.Id) 
                ?? throw new ArgumentException($"No ToDo found with id {entity.Id}",nameof(entity.Id));

            todo.ToDoItem = entity.ToDoItem;

            await SaveAsync();

            return await GetByIdAsync(entity.Id);
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
