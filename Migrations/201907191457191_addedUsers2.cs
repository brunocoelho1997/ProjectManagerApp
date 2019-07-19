namespace ProjectManagerApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUsers2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "applicationUser_Id" });
            DropColumn("dbo.Tasks", "applicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "applicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tasks", "applicationUser_Id");
            AddForeignKey("dbo.Tasks", "applicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
