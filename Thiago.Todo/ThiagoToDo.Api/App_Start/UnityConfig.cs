using ThiagoToDo.Services;
using System;
using ThiagoToDo.Services.Interfaces;
using Unity;
using ThiagoToDo.DataAccessLayer.Context;
using AutoMapper;
using ThiagoToDo.Api.Mapping;
using ThiagoToDo.Services.Mapping;
using System.Reflection;
using NLog;
using ThiagoToDoApp.DataAccessLayer.Abstractions;
using ThiagoToDo.DataAccessLayer.Entities;
using ThiagoToDoApp.DataAccessLayer;

namespace ThiagoToDo.Api
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              container.RegisterTypes();
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(this IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();


            //Transient
            container.RegisterType<ToDoDbContext>();
            container.RegisterType<IRepository<ToDo>, ToDoRepository>();
            container.RegisterType<IToDoService, ToDoService>();

            Mapper.Initialize(cfg => {
                cfg.AddServiceProfiler();
                cfg.AddApiProfiler();
            });

            //Singleton
            container.RegisterInstance(Mapper.Instance);
       
        }
    }
}