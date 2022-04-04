using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Цена")]
        public string Price { get; set; }

        [DisplayName("Дата регистрации")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Название заказа")]
        public string OrderName { get; set; }
        [DisplayName("Имя")]
        public string FIOClient { get; set; }
        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }

        public Dictionary<int, (string, decimal)> CosmeticsInOrder { get; set; }

        public Dictionary<int, (string, decimal)> ServicesInOrder { get; set; }
    }
}
