namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendNotifications",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Friend_ID = c.Int(nullable: false),
                        Read = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Time });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false, maxLength: 15, unicode: false),
                        Last_Name = c.String(nullable: false, maxLength: 15, unicode: false),
                        E_Mail = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 68, unicode: false),
                        Profile_Picture = c.DateTime(),
                        Phone_Number = c.String(maxLength: 20, unicode: false),
                        Gender = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                        Marital_Status = c.Byte(nullable: false),
                        About_me = c.String(unicode: false, storeType: "text"),
                        HomeTown = c.String(maxLength: 50, unicode: false),
                        FriendNotification_User_ID = c.Int(),
                        FriendNotification_Time = c.DateTime(),
                        FriendNotification_User_ID1 = c.Int(),
                        FriendNotification_Time1 = c.DateTime(),
                    })
                .PrimaryKey(t => t.User_Id)
                .ForeignKey("dbo.FriendNotifications", t => new { t.FriendNotification_User_ID, t.FriendNotification_Time })
                .ForeignKey("dbo.FriendNotifications", t => new { t.FriendNotification_User_ID1, t.FriendNotification_Time1 })
                .Index(t => new { t.FriendNotification_User_ID, t.FriendNotification_Time })
                .Index(t => new { t.FriendNotification_User_ID1, t.FriendNotification_Time1 });
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Caption = c.String(unicode: false, storeType: "text"),
                        Private_Public = c.Boolean(),
                        Has_Picture = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Time })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Post_Id = c.DateTime(nullable: false),
                        Like_Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Post_Id })
                .ForeignKey("dbo.Users", t => t.Like_Owner_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => new { t.User_Id, t.Post_Id })
                .Index(t => new { t.User_Id, t.Post_Id })
                .Index(t => t.Like_Owner_Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Friend_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Friend_Id, t.User_Id })
                .ForeignKey("dbo.Users", t => t.Friend_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Friend_Id)
                .Index(t => t.User_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" }, "dbo.FriendNotifications");
            DropForeignKey("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" }, "dbo.FriendNotifications");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Likes", new[] { "User_Id", "Post_Id" }, "dbo.Posts");
            DropForeignKey("dbo.Likes", "Like_Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", new[] { "Comment_User_Id", "Comment_Id" }, "dbo.Posts");
            DropForeignKey("dbo.Comments", new[] { "User_ID", "Post_Id" }, "dbo.Posts");
            DropForeignKey("dbo.Friends", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "Comment_User_Id", "Comment_Id" });
            DropIndex("dbo.Comments", new[] { "User_ID", "Post_Id" });
            DropIndex("dbo.Friends", new[] { "User_Id" });
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropIndex("dbo.Likes", new[] { "Like_Owner_Id" });
            DropIndex("dbo.Likes", new[] { "User_Id", "Post_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" });
            DropIndex("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" });
            DropTable("dbo.Comments");
            DropTable("dbo.Friends");
            DropTable("dbo.Likes");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.FriendNotifications");
        }
    }
}
