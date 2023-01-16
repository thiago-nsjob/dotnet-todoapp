using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Results;
using ThiagoToDo.Api.Controllers;
using ThiagoToDo.DataAccessLayer.Context;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDo.Services;
using ThiagoToDo.Services.DTOs;
using ThiagoToDo.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;
using ThiagoToDo.Services.Mapping;
using ThiagoToDo.Api.Mapping;
using ThiagoToDo.Api.Contracts;
using Unity;
using ThiagoToDo.Services.Interfaces;

namespace ThiagoToDo.Tests.Controllers
{
    [TestClass]
    public class ToDoControllerTest : TestBase
    {

        /* 
         * This test should not exist.
         * Integrated tests should use real dependencies ( in this Sql Server ) and the Api should be called over HTTP
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
        public async Task CreateToDoAsyncControllerTest()
        {
            // arrange
            var toDos = GetTestData();

            var mockToDoSet = SetupMockSetAsync(new Mock<DbSet<ToDo>>(), toDos);
            var mockContext = new Mock<ToDoDbContext>();
            var mockIoc = SetupIoC(new Mock<IUnityContainer>(), new ToDoService(mockContext.Object));
            var toDoController = new ToDoController(mockIoc.Object,Mapper.Instance);

            mockContext.Setup(s => s.ToDos).Returns(mockToDoSet.Object);

            var newToDo = new Api.Contracts.Requests.ToDo{
                Id = 4,
                Item = "Find my lost cat"
            };
           

            // act
            var controllerActionResult = await toDoController.CreateToDo(newToDo);

            // assert
            Assert.IsInstanceOfType(controllerActionResult, typeof(OkNegotiatedContentResult<bool>));
        }

        [TestMethod]
        public async Task GetToDoItemsAsyncControllerTest()
        {
            // arrange
            var toDos = GetTestData();

            var mockToDoSet = SetupMockSetAsync(new Mock<DbSet<ToDo>>(), toDos);
            var mockContext = new Mock<ToDoDbContext>();
            var mockIoc = SetupIoC(new Mock<IUnityContainer>(), new ToDoService(mockContext.Object));
            var toDoController = new ToDoController(mockIoc.Object, Mapper.Instance);

            mockContext.Setup(s => s.ToDos).Returns(mockToDoSet.Object);

            // act
            var controllerActionResult = await toDoController.GetToDos();

            // assert
            Assert.IsInstanceOfType(controllerActionResult, typeof(OkNegotiatedContentResult<IEnumerable<ToDoDTO>>));
        }
    }
}