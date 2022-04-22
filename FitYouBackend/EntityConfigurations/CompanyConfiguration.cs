using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(c => c.CompanyDetails)
                .WithRequired(cd => cd.Company)
                .HasForeignKey(cd => cd.CompanyId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Plans)
                .WithRequired(p => p.Company)
                .HasForeignKey(p => p.CompanyId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Offices)
                .WithRequired(o => o.Company)
                .HasForeignKey(o => o.CompanyId)
                .WillCascadeOnDelete(false);

        }
    }
}