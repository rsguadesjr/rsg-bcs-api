namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeRelationshipToHobbyAndInterestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hobbies", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Interests", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Hobbies", "EmployeeId");
            CreateIndex("dbo.Interests", "EmployeeId");
            AddForeignKey("dbo.Hobbies", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Interests", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropTable("dbo.EmployeeHobbies");
            DropTable("dbo.EmployeeInterests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeHobbies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HobbyId = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Interests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Hobbies", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Interests", new[] { "EmployeeId" });
            DropIndex("dbo.Hobbies", new[] { "EmployeeId" });
            DropColumn("dbo.Interests", "EmployeeId");
            DropColumn("dbo.Hobbies", "EmployeeId");
        }
    }
}
