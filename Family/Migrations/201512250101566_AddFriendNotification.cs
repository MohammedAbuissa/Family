namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriendNotification : DbMigration
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
            
            AddColumn("dbo.Users", "FriendNotification_User_ID", c => c.Int());
            AddColumn("dbo.Users", "FriendNotification_Time", c => c.DateTime());
            AddColumn("dbo.Users", "FriendNotification_User_ID1", c => c.Int());
            AddColumn("dbo.Users", "FriendNotification_Time1", c => c.DateTime());
            CreateIndex("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" });
            CreateIndex("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" });
            AddForeignKey("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" }, "dbo.FriendNotifications", new[] { "User_ID", "Time" });
            AddForeignKey("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" }, "dbo.FriendNotifications", new[] { "User_ID", "Time" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" }, "dbo.FriendNotifications");
            DropForeignKey("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" }, "dbo.FriendNotifications");
            DropIndex("dbo.Users", new[] { "FriendNotification_User_ID1", "FriendNotification_Time1" });
            DropIndex("dbo.Users", new[] { "FriendNotification_User_ID", "FriendNotification_Time" });
            DropColumn("dbo.Users", "FriendNotification_Time1");
            DropColumn("dbo.Users", "FriendNotification_User_ID1");
            DropColumn("dbo.Users", "FriendNotification_Time");
            DropColumn("dbo.Users", "FriendNotification_User_ID");
            DropTable("dbo.FriendNotifications");
        }
    }
}
