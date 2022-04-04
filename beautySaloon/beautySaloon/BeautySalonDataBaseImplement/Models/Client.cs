using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FIOClient { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Procedure> Procedures { get; set; }
    }
}
