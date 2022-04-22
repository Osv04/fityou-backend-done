using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class TelecableConfiguration : EntityTypeConfiguration<Telecable>
    {
        public TelecableConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Chanels)
                .IsRequired()
                .HasMaxLength(4);

            Property(t => t.TypeOfTelecable)
                .IsOptional()
                .HasMaxLength(30);

            Property(t => t.Description)
                .IsOptional()
                .HasMaxLength(250);

            HasMany(t => t.DetailPlans)
                .WithRequired(d => d.Telecable)
                .HasForeignKey(d => d.TelecableId)
                .WillCascadeOnDelete(false);

            HasMany(t => t.TelecablePackages)
                .WithRequired(tp => tp.Telecable)
                .HasForeignKey(tp => tp.TelecableId)
                .WillCascadeOnDelete(false);



        }
    }
}