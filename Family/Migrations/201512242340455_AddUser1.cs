namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "User_User_Id", c => c.Int());
            CreateIndex("dbo.Users", "User_User_Id");
            AddForeignKey("dbo.Users", "User_User_Id", "dbo.Users", "User_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_User_Id" });
            DropColumn("dbo.Users", "User_User_Id");
        }
    }
}
