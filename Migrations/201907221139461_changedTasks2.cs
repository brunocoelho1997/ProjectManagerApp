namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTasks2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            RenameColumn(table: "dbo.Tasks", name: "ProjectId", newName: "project_ProjectId");
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntityId", newName: "DeveloperEntity_Id");
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntityId", newName: "IX_DeveloperEntity_Id");
            AlterColumn("dbo.Tasks", "project_ProjectId", c => c.Int());
            CreateIndex("dbo.Tasks", "project_ProjectId");
            AddForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "project_ProjectId" });
            AlterColumn("dbo.Tasks", "project_ProjectId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntity_Id", newName: "IX_DeveloperEntityId");
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntity_Id", newName: "DeveloperEntityId");
            RenameColumn(table: "dbo.Tasks", name: "project_ProjectId", newName: "ProjectId");
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
