namespace ООП9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientChecks",
                c => new
                    {
                        Number = c.Int(nullable: false, identity: true),
                        CheckType = c.String(),
                        Balance = c.Double(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Owners", t => t.Owner_ID)
                .ForeignKey("dbo.Owners", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Fathername = c.String(),
                        Birth = c.DateTime(nullable: false, storeType: "date"),
                        PassportSeries = c.String(),
                        PassportNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.PassportNumber, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientChecks", "ClientID", "dbo.Owners");
            DropForeignKey("dbo.ClientChecks", "Owner_ID", "dbo.Owners");
            DropIndex("dbo.Owners", new[] { "PassportNumber" });
            DropIndex("dbo.ClientChecks", new[] { "Owner_ID" });
            DropIndex("dbo.ClientChecks", new[] { "ClientID" });
            DropTable("dbo.Owners");
            DropTable("dbo.ClientChecks");
        }
    }
}
