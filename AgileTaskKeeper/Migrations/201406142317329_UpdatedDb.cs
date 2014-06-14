namespace AgileTaskKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgileTasks",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Title);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgileTasks");
        }
    }
}
