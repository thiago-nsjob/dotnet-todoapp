using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDo.Tests.Providers;
using Moq;
using Unity;
using ThiagoToDoApp.DataAccessLayer.Abstractions;
using System.Net.Sockets;
using System.Collections;
using System.Data.Entity.Core.Metadata.Edm;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System;
using FluentValidation;

namespace ThiagoToDo.Tests.Base
{
    public static class MockContext
    {
       

        public static Mock<IRepository<ToDo>> SetupTodoRepo(Mock<IRepository<ToDo>> mockContext,  List<ToDo> data)
        {
            
            mockContext.As<IRepository<ToDo>>()
                .Setup(s => s.GetAllAsync())
                .ReturnsAsync(data.ToList());


            mockContext.As<IRepository<ToDo>>()
               .Setup(s => s.GetByIdAsync(It.IsAny<int>()))
               .ReturnsAsync((int id) => data.Where(item => item.Id == id).First());


            mockContext.As<IRepository<ToDo>>()
             .Setup(s => s.InsertAsync(It.IsAny<ToDo>()))
             .ReturnsAsync((ToDo item) => {
                 var nextId = data.Max(td => td.Id) +1;
                 item.Id = nextId;
                 return item; 
             });


            mockContext.As<IRepository<ToDo>>()
             .Setup(s => s.DeleteAsync(It.IsAny<int>()))
             .Returns(Task.CompletedTask);

            mockContext.As<IRepository<ToDo>>()
            .Setup(s => s.UpdateAsync(It.IsAny<ToDo>()))
            .ReturnsAsync((ToDo parm) =>
            {
                var todo = data.SingleOrDefault(item => item.Id == parm.Id) ?? 
                    throw new ArgumentException($"No ToDo found with id {parm.Id}", nameof(parm.Id));

                todo.ToDoItem = parm.ToDoItem;
                return todo;
            });


            return mockContext;
        }


        public static List<ToDo> MockTodoList = new List<ToDo>
            {
                new ToDo
                {
                    Id = 1,
                    ToDoItem = "Get a new bike"
                },
                new ToDo
                {
                    Id = 2,
                    ToDoItem = "Feed my dog"
                },
                new ToDo
                {
                    Id = 3,
                    ToDoItem = "Do my homework"
                }

            };
    }
}
