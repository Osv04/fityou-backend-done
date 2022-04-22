using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            Property(p => p.TypeOfPlan)
                .IsRequired()
                .HasMaxLength(1);

            Property(p => p.CreateDate)
                .IsRequired();
           
            Property(p => p.ActiveTime)
                .IsOptional()
                .HasMaxLength(30);

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(8,2);

            Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(3);

            Property(p => p.AdministratorId);

            Property(p => p.InternetId)
                .IsOptional();

            Property(p => p.TelecableId)
                .IsOptional();

            Property(p => p.TelephoneId)
                .IsOptional();

            Property(p => p.CompanyId)
                .IsRequired();


        }
    }
}