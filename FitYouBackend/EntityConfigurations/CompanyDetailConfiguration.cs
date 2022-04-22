using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class CompanyDetailConfiguration : EntityTypeConfiguration<CompanyDetail>
    {
        public CompanyDetailConfiguration()
        {
            HasKey(cd => cd.Id);

            Property(cd => cd.CompanyId)
                .IsRequired();

            Property(cd => cd.DetailPlanId)
                .IsRequired();

        }
    }
}