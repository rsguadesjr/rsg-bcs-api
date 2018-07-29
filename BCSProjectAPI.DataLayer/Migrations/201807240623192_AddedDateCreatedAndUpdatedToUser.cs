namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateCreatedAndUpdatedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateUpdated");
            DropColumn("dbo.Users", "DateCreated");
        }
    }
}
