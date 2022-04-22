using FitYouBackend.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class FityouContext : DbContext
    {
        public FityouContext() : base("FityouContext")
        {

        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        public DbSet<DetailPlan> DetailPlans { get; set; }
        public DbSet<Internet> Internets { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Telecable> Telecables { get; set; }
        public DbSet<TelecablePackage> TelecablePackages { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Office> Offices { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministratorConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CompanyDetailConfiguration());
            modelBuilder.Configurations.Add(new DetailPlanConfiguration());
            modelBuilder.Configurations.Add(new InternetConfiguration());
            modelBuilder.Configurations.Add(new PackageConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new TelecableConfiguration());
            modelBuilder.Configurations.Add(new TelecablePackageConfiguration());
            modelBuilder.Configurations.Add(new TelephoneConfiguration());
            modelBuilder.Configurations.Add(new OfficeConfiguration());

        }

    }
}