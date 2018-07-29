namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsLockedInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsLocked", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsLocked");
        }
    }
}
