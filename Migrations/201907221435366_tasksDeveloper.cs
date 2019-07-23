namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tasksDeveloper : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntity_Id", newName: "DeveloperEntityId");
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntity_Id", newName: "IX_DeveloperEntityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tasks", name: "IX_DeveloperEntityId", newName: "IX_DeveloperEntity_Id");
            RenameColumn(table: "dbo.Tasks", name: "DeveloperEntityId", newName: "DeveloperEntity_Id");
        }
    }
}
