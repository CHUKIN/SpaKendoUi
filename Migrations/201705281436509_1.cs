namespace Лаба2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.String(),
                        Year = c.Int(nullable: false),
                        Watch = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        State = c.String(),
                        Mileage = c.Double(nullable: false),
                        Type = c.String(),
                        Amount = c.String(),
                        Transmission = c.String(),
                        PhotoUrl = c.String(),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
