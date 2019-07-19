namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectManagerEntity_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tasks", "DeveloperEntity_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Projects", "ProjectManagerEntity_Id");
            CreateIndex("dbo.Tasks", "DeveloperEntity_Id");
            AddForeignKey("dbo.Tasks", "DeveloperEntity_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ProjectManagerEntity_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectManagerEntity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "DeveloperEntity_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "DeveloperEntity_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectManagerEntity_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Tasks", "DeveloperEntity_Id");
            DropColumn("dbo.Projects", "ProjectManagerEntity_Id");
        }
    }
}
