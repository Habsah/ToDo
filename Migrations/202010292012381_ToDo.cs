namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoes");
        }
    }
}
