namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCommentsCodeFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Post_Id = c.DateTime(nullable: false),
                        Comment_User_Id = c.Int(nullable: false),
                        Comment_Id = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Post_Id, t.Comment_User_Id, t.Comment_Id })
                .ForeignKey("dbo.Posts", t => new { t.User_ID, t.Post_Id })
                .ForeignKey("dbo.Posts", t => new { t.Comment_User_Id, t.Comment_Id })
                .Index(t => new { t.User_ID, t.Post_Id })
                .Index(t => new { t.Comment_User_Id, t.Comment_Id });
            
            CreateIndex("dbo.Likes", "Like_Owner_Id");
            AddForeignKey("dbo.Likes", "Like_Owner_Id", "dbo.Users", "User_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Like_Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", new[] { "Comment_User_Id", "Comment_Id" }, "dbo.Posts");
            DropForeignKey("dbo.Comments", new[] { "User_ID", "Post_Id" }, "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Comment_User_Id", "Comment_Id" });
            DropIndex("dbo.Comments", new[] { "User_ID", "Post_Id" });
            DropIndex("dbo.Likes", new[] { "Like_Owner_Id" });
            DropTable("dbo.Comments");
        }
    }
}
