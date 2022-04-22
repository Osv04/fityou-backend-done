using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class InternetConfiguration : EntityTypeConfiguration<Internet>
    {
        public InternetConfiguration()
        {
            HasKey(i => i.Id);

            Property(i => i.Uploadspeed)
                .IsRequired();

            Property(i => i.Loweringspeed)
                .IsRequired();

            Property(i => i.Speed)
                .IsRequired();

            Property(i => i.TypeOfNet)
                .IsRequired()
                .HasMaxLength(30);

            Property(i => i.Description)
                .IsOptional()
                .HasMaxLength(250);


            HasMany(i => i.DetailPlans)
                .WithRequired(d => d.Internet)
                .HasForeignKey(d => d.InternetId)
                .WillCascadeOnDelete(false);


        }
    }
}