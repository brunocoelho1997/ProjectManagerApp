namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Budget = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        DateLimit = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Projects", t => t.project_ProjectId)
                .Index(t => t.project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "project_ProjectId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
