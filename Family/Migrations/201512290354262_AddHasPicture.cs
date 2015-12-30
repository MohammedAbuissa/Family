namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Has_Picture", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Has_Picture");
        }
    }
}
