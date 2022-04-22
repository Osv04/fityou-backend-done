using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class PackageConfiguration : EntityTypeConfiguration<Package>
    {
        public PackageConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Descripcion)
                .IsOptional()
                .HasMaxLength(250);

            Property(p => p.Chanels)
                .IsRequired()
                .HasMaxLength(4);

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(8,2);

            HasMany(p => p.TelecablePackages)
                .WithRequired(tp => tp.Package)
                .HasForeignKey(tp => tp.PackageId)
                .WillCascadeOnDelete(false);

        }
    }
}