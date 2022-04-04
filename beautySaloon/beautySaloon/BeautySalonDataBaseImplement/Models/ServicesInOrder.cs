using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonDataBaseImplement.Models
{
    public class ServicesInOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; } 
        public int ServiceId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }    

    }
}
