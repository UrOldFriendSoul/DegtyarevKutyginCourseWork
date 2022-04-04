using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Cosmetic
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Model { get; set; }

        [ForeignKey("CosmeticId")]
        public virtual List<Service> Services { get; set; }

        [ForeignKey("CosmeticId")]
        public virtual List<LaborCosts> LaborCosts { get; set; }

    }
}
