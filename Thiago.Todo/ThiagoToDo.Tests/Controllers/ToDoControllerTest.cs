using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ThiagoToDo.Api.Controllers;
using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDo.Services;
using ThiagoToDo.Services.DTOs;
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
using System.Web.WebPages;
using FluentValidation;

namespace ThiagoToDo.Tests.Controllers
{
    [TestClass]
    public class ToDoControllerTest 
    {

        /* 
         * This tests should not be created like this.
         * Integrated tests should use real dependencies ( in this Sql Server ) and the Api should be called over HTTP with WebApplicationFactory
         * [dotnet core needed]
        */

        [ClassInitialize]
        public static void InitializeAutoMapper(TestContext testContext)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => {
                cfg.AddServiceProfiler();
                cfg.AddApiProfiler();
            });
            

        }

        [TestMethod]
        public async Task Post_ShouldCreateNewTodo_WhenTodoIsValid()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var newToDo = new Api.Contracts.ToDo
            {
                Item = "Find my lost cat"
            };

            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);
            var validator = new ToDoValidator();

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var toDoController = new ToDoController(toDoService, Mapper.Instance, validator);


            // act
            var controllerActionResult = await toDoController.Post(newToDo);

            // assert
            controllerActionResult.Should()
                .BeOfType<OkNegotiatedContentResult<Api.Contracts.ToDo>>();

            
        }

        [TestMethod]
        public async Task Get_ShouldGetAllToDos_WhenAny()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var newToDo = new Api.Contracts.ToDo
            {
                Item = "Find my lost cat"
            };

            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);
            var validator = new ToDoValidator(); 

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var toDoController = new ToDoController(toDoService, Mapper.Instance, validator);

            // act
            var controllerActionResult = await toDoController.GetAll();

            // assert
            controllerActionResult.Should()
                .BeOfType<OkNegotiatedContentResult<IEnumerable<Api.Contracts.ToDo>>>();

        }
        [TestMethod]
        public async Task Put_ShouldChangeTodo_WhenAny()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var newToDo = new Api.Contracts.ToDo
            {
                Id = 1,
                Item = "Find my lost cat"
            };

            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);
            var validator = new ToDoValidator();

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var toDoController = new ToDoController(toDoService, Mapper.Instance, validator);

            // act
            var controllerActionResult = await toDoController.Put(newToDo);

            // assert
            controllerActionResult.Should()
                .BeOfType<OkNegotiatedContentResult<Api.Contracts.ToDo>>();

        }

        [TestMethod]
        public async Task Delete_ShouldDeleteTodo_WhenAny()
        {
            // arrange
            var toDos = new List<ToDo>(MockRepo.MockTodoList);
            var newToDo = new Api.Contracts.ToDo
            {
                Item = "Find my lost cat"
            };

            var mockRepo = MockRepo.SetupTodoRepo(new Mock<IRepository<ToDo>>(), toDos);
            var validator = new ToDoValidator();

            // act
            var toDoService = new ToDoService(mockRepo.Object, Mapper.Instance);
            var toDoController = new ToDoController(toDoService, Mapper.Instance, validator);

            // act
            var controllerActionResult = await toDoController.Delete(3);

            // assert
            controllerActionResult.Should()
                .BeOfType<OkResult>();

        }
    }
}