namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartmentToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropColumn("dbo.Employees", "DepartmentId");
        }
    }
}
