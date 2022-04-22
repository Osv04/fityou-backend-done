using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class TelecablePackage
    {
        public int Id { get; set; }

        public Telecable Telecable { get; set; }
        public int TelecableId { get; set; }

        public Package Package { get; set; }
        public int PackageId { get; set; }

    }
}