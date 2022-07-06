
using FitYouBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FitYouBackend.EntityConfigurations
{
    public class TicketsConfiguration : EntityTypeConfiguration<Tickets>
    {
        public TicketsConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Status);

            Property(t => t.Description);

            Property(t => t.Title);
        }
    }
}