using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        [Required]
        public string ProcedureName { get; set; }

        [Required]
        public decimal ProcedureCost { get; set; }

        [ForeignKey("ProcedureId")]
        public virtual List<Estimate> Estimates { get; set; }

        [ForeignKey("ProcedureId")]
        public virtual List<Employee> Employees { get; set; }

    }
}
