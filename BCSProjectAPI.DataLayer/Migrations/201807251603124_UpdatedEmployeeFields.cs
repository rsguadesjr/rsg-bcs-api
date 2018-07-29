namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Interests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Interests", new[] { "EmployeeId" });
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime());
            DropTable("dbo.Interests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestName = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Interests", "EmployeeId");
            AddForeignKey("dbo.Interests", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
