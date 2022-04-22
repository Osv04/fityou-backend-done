using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class TelephoneConfiguration : EntityTypeConfiguration<Telephone>
    {
        public TelephoneConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Minutes)
                .IsRequired()
                .HasMaxLength(5);

            Property(t => t.Service)
                .IsRequired()
                .HasMaxLength(250);

            Property(t => t.Description)
                .IsOptional()
                .HasMaxLength(250);

             HasMany(t => t.DetailPlans)
                .WithRequired(d => d.Telephone)
                .HasForeignKey(d => d.TelephoneId)
                .WillCascadeOnDelete(false);


        }
    }
}