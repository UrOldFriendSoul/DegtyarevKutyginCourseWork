using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySalonDataBaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public string OrderName { get; set; }

        public string FIOClient { get; set; }

        public string ServiceName { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<ServicesInOrder> CosmeticsInOrder { get; set; }

    }
}
