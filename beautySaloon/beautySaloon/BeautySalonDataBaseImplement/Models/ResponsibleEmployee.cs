using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class ResponsibleEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LaborCostsId { get; set; }
        public int Services { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual LaborCosts LaborCosts { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
