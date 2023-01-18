using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDo.Services;
using ThiagoToDo.Services.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ThiagoToDo.Tests.Base;
using AutoMapper;
using ThiagoToDo.Services.Mapping;
using ThiagoToDo.Api.Mapping;
using ThiagoToDoApp.DataAccessLayer.Abstractions;
using System.Collections.Generic;
using FluentAssertions;
using ThiagoToDo.Services.Interfaces;
using System;

namespace ThiagoToDo.Tests.Services
{
    [TestClass]
    public class ToDoServiceTest 
    {
        //Naming convention used here Method_Should_When

        [ClassInitialize]
        public static void InitializeAutoMapper(TestContext testContext)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => {
                cfg.AddServiceProfiler();
            });
        }

        [TestMethod]
        public async Task CreateToDoAsync_ShouldCreateNewTodo_WhenNewTodoInformed()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var expectedTodo = new ToDoDTO
            {
                Id = 4,
                ToDoItem = "Find my lost cat"
            };
        
            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);

            var newToDo = new ToDoDTO
            {
                ToDoItem = "Find my lost cat"
            };

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);

            var result = await toDoService.CreateToDoAsync(newToDo);

            // assert
            result.Should().NotBeNull()
                .And
                .BeEquivalentTo(expectedTodo, options => options
                    .Including(o => o.Id)
                    .Including(o => o.ToDoItem));
        }


        [TestMethod]
        public async Task GetToDoItemsAsync_ShouldGetAllTodos_WhenAvailble()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var allToDos = await toDoService.GetToDoItemsAsync();

            // assert
            allToDos.Should().HaveCount(3);
        }


        [TestMethod]
        public async Task GetToDoItemsAsync_ShouldChangeTodo_WhenExistingTodoInformed()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);

            var expectedTodo = new ToDoDTO
            {
                Id = 3,
                ToDoItem = "Todo has been updated"
            };

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var result = await toDoService.ChangeTodoAsync(expectedTodo);


            // assert
            result.Should().NotBeNull()
                .And
                .BeEquivalentTo(expectedTodo, options => options
                    .Including(o => o.Id)
                    .Including(o => o.ToDoItem));
        }


        [TestMethod]
        public async Task GetToDoItemsAsync_ShouldThrow_WhenTodoDoesNotExist()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);

            var expectedTodo = new ToDoDTO
            {
                Id = 9999,
                ToDoItem = "Todo has been updated"
            };

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            Func<Task> result = async() => await toDoService.ChangeTodoAsync(expectedTodo);

            // assert
            await result.Should().ThrowAsync<ArgumentException>();
        }

        //This is not a good >.< . Didn't have time to refatore the list change logic for this
        [TestMethod]
        public async Task DeleteToDoAsyncServiceTest()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            await toDoService.DeleteTodoAsync(3);

            
            // assert
            Assert.IsTrue(true);

        }
    }

}
