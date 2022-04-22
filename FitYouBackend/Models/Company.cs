using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Company
    {
        public Company()
        {
            Plans = new HashSet<Plan>();
            CompanyDetails = new HashSet<CompanyDetail>(); 
            Offices = new HashSet<Office>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }

        public virtual ICollection<CompanyDetail> CompanyDetails { get; set; }

        public virtual ICollection<Office> Offices { get; set; }

    }
}