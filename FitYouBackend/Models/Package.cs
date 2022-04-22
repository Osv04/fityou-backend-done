using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Package
    {

        public Package()
        {
            TelecablePackages = new HashSet<TelecablePackage>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public string Chanels { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<TelecablePackage> TelecablePackages { get; set; }
    }
}