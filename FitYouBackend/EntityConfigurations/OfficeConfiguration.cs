using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class OfficeConfiguration : EntityTypeConfiguration<Office>
    {
        public OfficeConfiguration()
        {
            HasKey(o => o.Id);

            Property(o => o.Latitude)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(o => o.Longitude)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(o => o.PhoneNumber)
                .IsOptional()
                .HasMaxLength(30);

            Property(o => o.CompanyId)
                .IsRequired();

            

        }
    }
}