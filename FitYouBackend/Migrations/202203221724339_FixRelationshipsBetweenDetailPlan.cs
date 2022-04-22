namespace FitYouBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelationshipsBetweenDetailPlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Internets", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.Telecables", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.Telephones", "Id", "dbo.DetailPlans");
            DropForeignKey("dbo.TelecablePackages", "TelecableId", "dbo.Telecables");
            DropIndex("dbo.Internets", new[] { "Id" });
            DropIndex("dbo.Telecables", new[] { "Id" });
            DropIndex("dbo.Telephones", new[] { "Id" });
            DropPrimaryKey("dbo.Internets");
            DropPrimaryKey("dbo.Telecables");
            DropPrimaryKey("dbo.Telephones");
            AlterColumn("dbo.DetailPlans", "InternetId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPlans", "TelecableId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPlans", "TelephoneId", c => c.Int(nullable: false));
            AlterColumn("dbo.Internets", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Telecables", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Telephones", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Internets", "Id");
            AddPrimaryKey("dbo.Telecables", "Id");
            AddPrimaryKey("dbo.Telephones", "Id");
            CreateIndex("dbo.DetailPlans", "InternetId");
            CreateIndex("dbo.DetailPlans", "TelecableId");
            CreateIndex("dbo.DetailPlans", "TelephoneId");
            AddForeignKey("dbo.DetailPlans", "InternetId", "dbo.Internets", "Id");
            AddForeignKey("dbo.DetailPlans", "TelecableId", "dbo.Telecables", "Id");
            AddForeignKey("dbo.DetailPlans", "TelephoneId", "dbo.Telephones", "Id");
            AddForeignKey("dbo.TelecablePackages", "TelecableId", "dbo.Telecables", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelecablePackages", "TelecableId", "dbo.Telecables");
            DropForeignKey("dbo.DetailPlans", "TelephoneId", "dbo.Telephones");
            DropForeignKey("dbo.DetailPlans", "TelecableId", "dbo.Telecables");
            DropForeignKey("dbo.DetailPlans", "InternetId", "dbo.Internets");
            DropIndex("dbo.DetailPlans", new[] { "TelephoneId" });
            DropIndex("dbo.DetailPlans", new[] { "TelecableId" });
            DropIndex("dbo.DetailPlans", new[] { "InternetId" });
            DropPrimaryKey("dbo.Telephones");
            DropPrimaryKey("dbo.Telecables");
            DropPrimaryKey("dbo.Internets");
            AlterColumn("dbo.Telephones", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Telecables", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Internets", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPlans", "TelephoneId", c => c.Int());
            AlterColumn("dbo.DetailPlans", "TelecableId", c => c.Int());
            AlterColumn("dbo.DetailPlans", "InternetId", c => c.Int());
            AddPrimaryKey("dbo.Telephones", "Id");
            AddPrimaryKey("dbo.Telecables", "Id");
            AddPrimaryKey("dbo.Internets", "Id");
            CreateIndex("dbo.Telephones", "Id");
            CreateIndex("dbo.Telecables", "Id");
            CreateIndex("dbo.Internets", "Id");
            AddForeignKey("dbo.TelecablePackages", "TelecableId", "dbo.Telecables", "Id");
            AddForeignKey("dbo.Telephones", "Id", "dbo.DetailPlans", "Id");
            AddForeignKey("dbo.Telecables", "Id", "dbo.DetailPlans", "Id");
            AddForeignKey("dbo.Internets", "Id", "dbo.DetailPlans", "Id");
        }
    }
}
