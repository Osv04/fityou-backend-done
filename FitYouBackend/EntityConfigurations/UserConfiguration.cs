using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}