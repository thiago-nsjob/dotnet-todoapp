namespace ThiagoToDo.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToDoItem = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDo");
        }
    }
}
