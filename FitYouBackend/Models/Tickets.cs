using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}