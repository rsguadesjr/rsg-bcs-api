namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLoginAttemptToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LoginAttempt", c => c.Byte(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LoginAttempt");
        }
    }
}
