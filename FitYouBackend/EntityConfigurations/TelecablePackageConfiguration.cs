using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class TelecablePackageConfiguration : EntityTypeConfiguration<TelecablePackage>
    {
        public TelecablePackageConfiguration()
        {
            HasKey(tp => tp.Id);

            Property(tp => tp.TelecableId)
                .IsRequired();

            Property(tp => tp.PackageId)
                .IsRequired();


        }
    }
}