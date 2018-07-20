namespace BCSProjectAPI.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCharacteristicsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeCharacteristics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CharacteristicId = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characteristics", t => t.CharacteristicId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CharacteristicId);
            
            CreateTable(
                "dbo.Characteristics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeCharacteristics", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeCharacteristics", "CharacteristicId", "dbo.Characteristics");
            DropIndex("dbo.EmployeeCharacteristics", new[] { "CharacteristicId" });
            DropIndex("dbo.EmployeeCharacteristics", new[] { "EmployeeId" });
            DropTable("dbo.Characteristics");
            DropTable("dbo.EmployeeCharacteristics");
        }
    }
}
