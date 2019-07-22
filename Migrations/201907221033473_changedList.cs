namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedList : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "ProjectManagerEntity_Id", newName: "ProjectManagerEntityId");
            RenameIndex(table: "dbo.Projects", name: "IX_ProjectManagerEntity_Id", newName: "IX_ProjectManagerEntityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_ProjectManagerEntityId", newName: "IX_ProjectManagerEntity_Id");
            RenameColumn(table: "dbo.Projects", name: "ProjectManagerEntityId", newName: "ProjectManagerEntity_Id");
        }
    }
}
