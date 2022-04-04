using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class LaborCosts
    {
        public int Id { get; set; }

        [Required]
        public DateTime LeadTime { get; set; }

        public int ServiceId { get; set; }

        public DateTime DateCreate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Service Service { get; set; }

        public virtual Employee Employee { get; set; }

        public string FIOEmployee { get; set; }
    }
}
