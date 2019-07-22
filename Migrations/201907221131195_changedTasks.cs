namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTasks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "project_ProjectId" });
            RenameColumn(table: "dbo.Tasks", name: "project_ProjectId", newName: "ProjectId");
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntity_Id", newName: "DeveloperEntityId");
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntity_Id", newName: "IX_DeveloperEntityId");
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int());
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntityId", newName: "IX_DeveloperEntity_Id");
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntityId", newName: "DeveloperEntity_Id");
            RenameColumn(table: "dbo.Tasks", name: "ProjectId", newName: "project_ProjectId");
            CreateIndex("dbo.Tasks", "project_ProjectId");
            AddForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
