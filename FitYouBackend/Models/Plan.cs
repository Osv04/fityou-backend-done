using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Plan
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeOfPlan { get; set; }
        public DateTime CreateDate { get; set; }
        public string ActiveTime { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Administrator Administrator { get; set; }

        
        public int AdministratorId { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public Internet Internet { get; set; }
        public int? InternetId { get; set; }

        public Telecable Telecable { get; set; }
        public int? TelecableId { get; set; }

        public Telephone Telephone { get; set; }
        public int? TelephoneId { get; set; }


    }
}