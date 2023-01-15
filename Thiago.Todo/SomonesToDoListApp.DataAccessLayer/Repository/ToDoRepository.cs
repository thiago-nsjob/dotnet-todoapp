using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiagoToDoApp.DataAccessLayer.Abstractions;

namespace ThiagoToDoApp.DataAccessLayer
{
    public class ToDoRepository: IRepository
    {
        private readonly DbContext _dbContext;
        public ToDoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
