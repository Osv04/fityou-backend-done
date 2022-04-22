using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Internet
    {
        public int Id { get; set; }

        public int Uploadspeed { get; set; }

        public int Loweringspeed { get; set; }

        public int Speed { get; set; }

        public string TypeOfNet { get; set; }

        public string Description { get; set; }

        //public Plan Plan { get; set; }

        //public int PlanId { get; set; }

        public virtual ICollection<DetailPlan> DetailPlans { get; set; }
    }
}