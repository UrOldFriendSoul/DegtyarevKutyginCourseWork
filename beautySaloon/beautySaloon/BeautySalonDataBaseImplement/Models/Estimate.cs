using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Estimate
    {
        public int Id { get; set; }

        public string Service { get; set; }

        public DateTime DateCreate { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [ForeignKey("EstimateId")]
        public virtual List<Procedure> Procedures { get; set; } 
    }
}
