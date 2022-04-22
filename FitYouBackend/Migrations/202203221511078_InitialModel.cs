namespace FitYouBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 80),
                        Name = c.String(nullable: false, maxLength: 50),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 1000),
                        TypeOfPlan = c.String(nullable: false, maxLength: 1),
                        CreateDate = c.DateTime(nullable: false),
                        ActiveTime = c.String(maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Currency = c.String(nullable: false, maxLength: 3),
                        AdministratorId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Administrators", t => t.AdministratorId)
                .Index(t => t.AdministratorId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        DetailPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailPlans", t => t.DetailPlanId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId)
                .Index(t => t.DetailPlanId);
            
            CreateTable(
                "dbo.DetailPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InternetId = c.Int(),
                        TelecableId = c.Int(),
                        TelephoneId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Internets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Uploadspeed = c.Int(nullable: false),
                        Loweringspeed = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        TypeOfNet = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailPlans", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Telecables",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Chanels = c.String(nullable: false, maxLength: 4),
                        TypeOfTelecable = c.String(maxLength: 30),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailPlans", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TelecablePackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelecableId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Telecables", t => t.TelecableId)
                .Index(t => t.TelecableId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 250),
                        Chanels = c.String(nullable: false, maxLength: 4),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Minutes = c.String(nullable: false, maxLength: 5),
                        Service = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailPlans", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "AdministratorId", "dbo.Administrators");
            DropForeignKey("dbo.Plans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyDetails", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Telephones", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.Telecables", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.TelecablePackages", "TelecableId", "dbo.Telecables");
            DropForeignKey("dbo.TelecablePackages", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Internets", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.CompanyDetails", "DetailPlanId", "dbo.DetailPlans");
            DropIndex("dbo.Telephones", new[] { "Id" });
            DropIndex("dbo.TelecablePackages", new[] { "PackageId" });
            DropIndex("dbo.TelecablePackages", new[] { "TelecableId" });
            DropIndex("dbo.Telecables", new[] { "Id" });
            DropIndex("dbo.Internets", new[] { "Id" });
            DropIndex("dbo.CompanyDetails", new[] { "DetailPlanId" });
            DropIndex("dbo.CompanyDetails", new[] { "CompanyId" });
            DropIndex("dbo.Plans", new[] { "CompanyId" });
            DropIndex("dbo.Plans", new[] { "AdministratorId" });
            DropTable("dbo.Telephones");
            DropTable("dbo.Packages");
            DropTable("dbo.TelecablePackages");
            DropTable("dbo.Telecables");
            DropTable("dbo.Internets");
            DropTable("dbo.DetailPlans");
            DropTable("dbo.CompanyDetails");
            DropTable("dbo.Companies");
            DropTable("dbo.Plans");
            DropTable("dbo.Administrators");
        }
    }
}
