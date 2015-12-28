namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasePasswordField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 68, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 64, unicode: false));
        }
    }
}
