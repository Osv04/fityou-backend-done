using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Telephone
    {
        public int Id { get; set; }
        public string Minutes { get; set; }
        public string Service { get; set; } 
        public string Description { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
    }
}