namespace AgileTaskKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyaddinstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgileTasks", "TaskStatusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgileTasks", "TaskStatusId");
        }
    }
}
