using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public DateTime DateCreate { get; set; }

        public string FIOEmployee { get; set; }

        public DateTime LaborCosts { get; set; } 

        public int EmployeeId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual List<ServicesInOrder> ServicesInOrder { get; set; }

    }
}
