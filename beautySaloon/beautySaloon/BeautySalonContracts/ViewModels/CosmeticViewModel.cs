using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace BeautySalonContracts.ViewModels
{
    public class CosmeticViewModel
    {
        public int Id { get; set; }

        [DisplayName("Бренд")]
        public string Brand { get; set; }

        [DisplayName("Цена")]
        public decimal Cost { get; set; }

        [DisplayName("Тип")]
        public string Type { get; set; }

        [DisplayName("Модель")]
        public string Model { get; set; }
    }
}
