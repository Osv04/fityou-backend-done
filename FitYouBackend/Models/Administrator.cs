using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitYouBackend.Models
{
    public class Administrator
    {
        public Administrator()
        {
            Plans = new HashSet<Plan>();
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}