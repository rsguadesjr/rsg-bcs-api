namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCharLimitToUsernameAndPassword : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            CreateIndex("dbo.Users", "Username", unique: true);
        }
    }
}
