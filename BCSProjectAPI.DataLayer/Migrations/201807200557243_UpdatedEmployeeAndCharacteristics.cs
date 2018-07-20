namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeAndCharacteristics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CivilStatus", c => c.String());
            AddColumn("dbo.Characteristics", "ColumnName", c => c.String());
            AddColumn("dbo.Characteristics", "ColumnText", c => c.String());
            DropColumn("dbo.Characteristics", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characteristics", "Name", c => c.String());
            DropColumn("dbo.Characteristics", "ColumnText");
            DropColumn("dbo.Characteristics", "ColumnName");
            DropColumn("dbo.Employees", "CivilStatus");
        }
    }
}
