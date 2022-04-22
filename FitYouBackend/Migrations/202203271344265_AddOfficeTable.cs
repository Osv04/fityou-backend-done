namespace FitYouBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.String(nullable: false, maxLength: 50),
                        Longitude = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 30),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offices", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Offices", new[] { "CompanyId" });
            DropTable("dbo.Offices");
        }
    }
}
