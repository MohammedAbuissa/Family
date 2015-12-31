namespace Family.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqness : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "E_Mail", unique: true, name: "EmailIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "EmailIndex");
        }
    }
}
