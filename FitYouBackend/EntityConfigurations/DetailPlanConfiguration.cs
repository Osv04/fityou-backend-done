using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class DetailPlanConfiguration : EntityTypeConfiguration<DetailPlan>
    {
        public DetailPlanConfiguration()
        {
            HasKey(d => d.Id);

            Property(d => d.InternetId)
                .IsOptional();

            Property(d => d.TelecableId)
                .IsOptional();

            Property(d => d.TelephoneId)
                .IsOptional();

            HasMany(d => d.CompanyDetails)
                .WithRequired(cd => cd.DetailPlan)
                .HasForeignKey(cd => cd.DetailPlanId)
                .WillCascadeOnDelete(false);



        }
    }
}