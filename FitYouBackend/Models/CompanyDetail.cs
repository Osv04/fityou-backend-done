using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class CompanyDetail
    {
        public int Id { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public DetailPlan DetailPlan { get; set; }
        public int DetailPlanId { get; set; }



    }
}