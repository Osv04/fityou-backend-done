using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class AdministratorConfiguration : EntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
            HasKey(a => a.Id);

            Property(a => a.Username)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(a => a.Password)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            Property(a => a.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(a => a.Lastname)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(a => a.Email)
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            HasMany(a => a.Plans)
                .WithRequired(p => p.Administrator)
                .HasForeignKey(p => p.AdministratorId)
                .WillCascadeOnDelete(false);



        }


    }
}