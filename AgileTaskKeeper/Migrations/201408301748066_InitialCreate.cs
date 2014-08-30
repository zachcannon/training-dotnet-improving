namespace AgileTaskKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgileTasks",
                c => new
                    {
                        AgileTaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.AgileTaskId);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        TeamMemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeamMemberId);
            
            CreateTable(
                "dbo.TeamMemberAgileTasks",
                c => new
                    {
                        TeamMember_TeamMemberId = c.Int(nullable: false),
                        AgileTask_AgileTaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamMember_TeamMemberId, t.AgileTask_AgileTaskId })
                .ForeignKey("dbo.TeamMembers", t => t.TeamMember_TeamMemberId, cascadeDelete: true)
                .ForeignKey("dbo.AgileTasks", t => t.AgileTask_AgileTaskId, cascadeDelete: true)
                .Index(t => t.TeamMember_TeamMemberId)
                .Index(t => t.AgileTask_AgileTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMemberAgileTasks", "AgileTask_AgileTaskId", "dbo.AgileTasks");
            DropForeignKey("dbo.TeamMemberAgileTasks", "TeamMember_TeamMemberId", "dbo.TeamMembers");
            DropIndex("dbo.TeamMemberAgileTasks", new[] { "AgileTask_AgileTaskId" });
            DropIndex("dbo.TeamMemberAgileTasks", new[] { "TeamMember_TeamMemberId" });
            DropTable("dbo.TeamMemberAgileTasks");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.AgileTasks");
        }
    }
}
