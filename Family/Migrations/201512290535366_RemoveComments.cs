namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", new[] { "Post1_User_Id", "Post1_Time" }, "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "Post1_User_Id", "Post1_Time" });
            //DropColumn("dbo.Posts", "Post1_User_Id");
            //DropColumn("dbo.Posts", "Post1_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Post1_Time", c => c.DateTime());
            AddColumn("dbo.Posts", "Post1_User_Id", c => c.Int());
            CreateIndex("dbo.Posts", new[] { "Post1_User_Id", "Post1_Time" });
            AddForeignKey("dbo.Posts", new[] { "Post1_User_Id", "Post1_Time" }, "dbo.Posts", new[] { "User_Id", "Time" });
        }
    }
}
