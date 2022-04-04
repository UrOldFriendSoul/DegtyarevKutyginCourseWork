using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FIOEmployee { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Services { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual List<LaborCosts> LaborCosts { get; set; }

        public virtual List<ResponsibleEmployee> ResponsibleEmployees { get; set; }

    }
}
