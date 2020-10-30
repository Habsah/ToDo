namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "IsMarked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoes", "IsMarked");
        }
    }
}
