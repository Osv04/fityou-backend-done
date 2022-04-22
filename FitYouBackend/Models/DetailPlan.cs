using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class DetailPlan
    {
        public DetailPlan()
        {
            CompanyDetails = new HashSet<CompanyDetail>();
        }

        public int Id { get; set; }

        public Internet Internet { get; set; }
        public int? InternetId { get; set; }

        public Telecable Telecable { get; set; }
        public int? TelecableId { get; set; }

        public Telephone Telephone { get; set; }
        public int? TelephoneId { get; set; }

        public virtual ICollection<CompanyDetail> CompanyDetails { get; set; }

    }
}