namespace DDACMaerskCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDependencies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerDescription = c.String(nullable: false),
                        ContainerWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.ContainerShippingSchedules",
                c => new
                    {
                        ContainerShippingScheduleID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        DepartureShipyardID = c.Int(nullable: false),
                        ArrivalShipyardID = c.Int(nullable: false),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArrivalDateTime = c.DateTime(nullable: false),
                        PriceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerShippingScheduleID)
                .ForeignKey("dbo.YardLocations", t => t.ArrivalShipyardID, cascadeDelete: false)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.YardLocations", t => t.DepartureShipyardID, cascadeDelete: false)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.DepartureShipyardID)
                .Index(t => t.ArrivalShipyardID);
            
            CreateTable(
                "dbo.YardLocations",
                c => new
                    {
                        YardLocationID = c.Int(nullable: false, identity: true),
                        YardName = c.String(nullable: false),
                        LocationName = c.String(nullable: false),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.YardLocationID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipType = c.String(),
                        ShipWeight = c.Int(nullable: false),
                        TotalContainers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.UserTokenCaches",
                c => new
                    {
                        UserTokenCacheId = c.Int(nullable: false, identity: true),
                        webUserUniqueId = c.String(),
                        cacheBits = c.Binary(),
                        LastWrite = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserTokenCacheId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContainerShippingSchedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.ContainerShippingSchedules", "DepartureShipyardID", "dbo.YardLocations");
            DropForeignKey("dbo.ContainerShippingSchedules", "ContainerID", "dbo.Containers");
            DropForeignKey("dbo.ContainerShippingSchedules", "ArrivalShipyardID", "dbo.YardLocations");
            DropIndex("dbo.ContainerShippingSchedules", new[] { "ArrivalShipyardID" });
            DropIndex("dbo.ContainerShippingSchedules", new[] { "DepartureShipyardID" });
            DropIndex("dbo.ContainerShippingSchedules", new[] { "ContainerID" });
            DropIndex("dbo.ContainerShippingSchedules", new[] { "ShipID" });
            DropTable("dbo.UserTokenCaches");
            DropTable("dbo.Ships");
            DropTable("dbo.YardLocations");
            DropTable("dbo.ContainerShippingSchedules");
            DropTable("dbo.Containers");
        }
    }
}
