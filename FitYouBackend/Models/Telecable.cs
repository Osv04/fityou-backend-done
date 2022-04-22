using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Telecable
    {
        public Telecable()
        {
            TelecablePackages = new HashSet<TelecablePackage>();
        }

        public int Id { get; set; }

        public string Chanels { get; set; }

        public string TypeOfTelecable { get; set; }

        public string Description { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
        public virtual ICollection<TelecablePackage> TelecablePackages { get; set; }
    }
}