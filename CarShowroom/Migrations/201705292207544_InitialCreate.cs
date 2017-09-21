namespace CarShowroom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsNew = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.WorkerId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Pesel = c.String(nullable: false, maxLength: 11),
                        City = c.String(nullable: false, maxLength: 11),
                        Street = c.String(nullable: false, maxLength: 11),
                        StreetNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Pesel = c.String(nullable: false, maxLength: 11),
                        City = c.String(nullable: false, maxLength: 11),
                        Street = c.String(nullable: false, maxLength: 11),
                        StreetNumber = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkerId)
                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFullTime = c.Boolean(nullable: false),
                        IsContract = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "WorkerId", "dbo.Worker");
            DropForeignKey("dbo.Worker", "PositionId", "dbo.Position");
            DropForeignKey("dbo.Purchase", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Purchase", "CarId", "dbo.Car");
            DropIndex("dbo.Worker", new[] { "PositionId" });
            DropIndex("dbo.Purchase", new[] { "CarId" });
            DropIndex("dbo.Purchase", new[] { "WorkerId" });
            DropIndex("dbo.Purchase", new[] { "ClientId" });
            DropTable("dbo.Position");
            DropTable("dbo.Worker");
            DropTable("dbo.Client");
            DropTable("dbo.Purchase");
            DropTable("dbo.Car");
        }
    }
}
