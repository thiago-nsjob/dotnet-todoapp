using SomeonesToDoListApp.DataAccessLayer.Context;
using SomeonesToDoListApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeonesToDoListApp.DataAccessLayer.Migrations
{
    //Latest Visual Studio need EF6 6.4.4
    //https://stackoverflow.com/questions/41777590/entity-framework-value-cannot-be-null-parameter-name-type
    internal sealed class Configuration : DbMigrationsConfiguration<ToDoDbContext>
    {
        /// <inheritdoc />
        /// <summary>
        /// Configuring the migrations behaviour in Entity Framework
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <inheritdoc />
        /// <summary>
        /// A seed method for a layer of base data for the to do list
        /// </summary>
        /// <param name="dbContext"></param>
        protected override void Seed(ToDoDbContext dbContext)
        {
            if (dbContext.ToDos.Any()) return;

            var toDo = new ToDo
            {
                Id = 1,
                ToDoItem = "Upgrade to .Net 6 !"
            };

            dbContext.ToDos.AddOrUpdate(toDo);

        }

    }
}
